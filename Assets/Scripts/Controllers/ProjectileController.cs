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
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
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
        //trailRenderer.Clear();//�ʿ������ ����        

        isReady = true;
    }
    public void player1ChargeAttack(Vector2 direction, BulletSO bulletSO, double chargeGage)
    {

        Debug.Log("Player1 Special Attack");
        this.attackData = bulletSO;
        this.direction = direction;
        Debug.Log(attackData);

        //trailRenderer.Clear();//�ʿ������ ����        

        isReady = true;
    }
    public void player2ChargeAttack(Vector2 direction, BulletSO bulletSO, double chargeGage)
    {

        Debug.Log("Player2 Special Attack");
        this.attackData = bulletSO;
        this.direction = direction;


        chargeGage = chargeGage < 1 ? chargeGage : 1;
        UpdateProjectile(chargeGage);
        //trailRenderer.Clear();//�ʿ������ ����        

        isReady = true;
    }

    private void UpdateProjectile()//�پ��� ���� ���� ������Ʈ
    {
        transform.localScale = Vector3.one * attackData.size;
    }
    private void UpdateProjectile(double chargeGage)//�پ��� ���� ���� ������Ʈ
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
        else if (IsLayerMatched(attackData.targetLayer, collision.gameObject.layer))
        {
            //������ ��� �ʿ�
            healthSystem = collision.GetComponent<HealthSystem>();
            healthSystem.ChangeHP(-attackData.damage);
            Debug.Log(attackData.damage + "  " + healthSystem.CurrentHp);

            DestroyProjectile(collision.ClosestPoint(transform.position));
        }

    }

    private bool IsLayerMatched(int value, int layer)//���̾� ����ũ�� 2���� ���������� 2������ �ƴϴ�. 
    {
        return value == (value | 1 << layer);//���� ���ϴ� ��ȣ�� ���̾� ����ũ���� Ȯ��, �ٸ� ���̾�� �Ҽ����� ���� �ƴ��� �� �� ����
    }

    private void DestroyProjectile(Vector2 destroyPosition)
    {
        //�ı� ����Ʈ �߰� �� ��ġ ������ �ʿ�
        gameObject.SetActive(false);
        timeAfterShoot = 0;
    }
}
