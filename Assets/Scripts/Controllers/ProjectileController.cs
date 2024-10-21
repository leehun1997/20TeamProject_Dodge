using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private bool isReady;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;
    private HealthSystem healthSystem;

    public BulletSO attackData;
    private Vector2 direction;
    private float timeAfterShoot = 0f;
    private bool fxDestroy = true;

    private void Awake()
    {
        rigidbody= GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        trailRenderer= GetComponent<TrailRenderer>();
    }

    private void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isReady)
        {
            return;
        }

        timeAfterShoot += Time.deltaTime;

        if (timeAfterShoot > attackData.duration)
        {
            DestroyProjectile(transform.position);
        }
        rigidbody.velocity = direction.normalized * attackData.speed;
    }

    public void InitiateAttack(Vector2 direction, BulletSO bulletSO)
    {
        Debug.Log("InitiateAttack");
        this.attackData = bulletSO;
        this.direction = direction;

        UpdateProjectile();
        //trailRenderer.Clear();//필요없으면 제거        

        isReady= true;
    }
    public void player1ChargeAttack(Vector2 direction, BulletSO bulletSO, double chargeGage)
    {
        
        Debug.Log("Player1 Special Attack");
        this.attackData = bulletSO;
        this.direction = direction;
        Debug.Log(attackData);

        //trailRenderer.Clear();//필요없으면 제거        

        isReady = true;
    }
    public void player2ChargeAttack(Vector2 direction, BulletSO bulletSO, double chargeGage)
    {

        Debug.Log("Player2 Special Attack");
        this.attackData = bulletSO;
        this.direction = direction;
        //attackData.duration = 0.5f;

        chargeGage = chargeGage < 2 ? chargeGage: 2;
        UpdateProjectile(chargeGage);
        //trailRenderer.Clear();//필요없으면 제거        

        isReady = true;
    }

    private void UpdateProjectile()//다양한 공격 정보 업데이트
    {
        transform.localScale = Vector3.one * attackData.size;
    }
    private void UpdateProjectile(double chargeGage)//다양한 공격 정보 업데이트
    {
        transform.localScale = Vector3.one * (float)chargeGage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerMatched(levelCollisionLayer.value, collision.gameObject.layer))
        {
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * 0.2f;


            DestroyProjectile(destroyPosition);
        }
        else if(IsLayerMatched(attackData.targetLayer , collision.gameObject.layer))
        {
            //데미지 계산 필요
            healthSystem = collision.GetComponent<HealthSystem>();
            healthSystem.ChangeHP(-attackData.damage);
            Debug.Log(attackData.damage + "  " + healthSystem.CurrentHp);

            DestroyProjectile(collision.ClosestPoint(transform.position));
        }
    }

    private bool IsLayerMatched(int value, int layer)//레이어 마스크는 2진수 개념이지만 2진수는 아니다. 
    {
        return value == (value | 1 << layer);//내가 원하는 번호의 레이어 마스크인지 확인, 다른 레이어면 불순물이 들어가서 아님을 알 수 있음
    }

    private void DestroyProjectile(Vector2 destroyPosition)
    {
        //파괴 이펙트 추가 시 위치 정보가 필요
        gameObject.SetActive(false);
    }
}
