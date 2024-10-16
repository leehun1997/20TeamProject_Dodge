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

    //private BulletSO attackData;
    private Vector2 direction;
    private float timeAfterShoot = 0f;
    private bool fxDestroy = true;

    private void Awake()
    {
        rigidbody= GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        //trailRenderer= GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady)
        {
            return;
        }

        timeAfterShoot += Time.deltaTime;

        //if(timeAfterShoot > attackData.duration)
        //{
        //    DestroyProjectile(transform.position);
        //}

        //rigidbody.velocity = direction * attackData.speed;
    }

    public void InitiateAttack(Vector2 direction)//, BulletSO bulletSO)
    {
        //this.attackData = bulletSO;
        this.direction = direction;

        UpdateProjectileSprite();
        //trailRenderer.Clear();//�ʿ������ ����        

        isReady= true;
    }

    private void UpdateProjectileSprite()//�پ��� ���� ���� ������Ʈ
    {
        transform.localScale = Vector3.one;// * attackData.size
        //spriteRenderer.color = bulletSO.projectilrColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerMatched(levelCollisionLayer.value, collision.gameObject.layer))
        {
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * 0.2f;
            DestroyProjectile(destroyPosition);
        }
        //else if(attackData.target.value, collision.gameObject.layer)
        //{
        //    //������ ��� �ʿ�
        //    DestroyProjectile(collision.ClosestPoint(transform.position));
        //}
    }

    private bool IsLayerMatched(int value, int layer)//���̾� ����ũ�� 2���� ���������� 2������ �ƴϴ�. 
    {
        return value == (value | 1 << layer);//���� ���ϴ� ��ȣ�� ���̾� ����ũ���� Ȯ��, �ٸ� ���̾�� �Ҽ����� ���� �ƴ��� �� �� ����
    }

    private void DestroyProjectile(Vector2 destroyPosition)
    {
        //�ı� ����Ʈ �߰� �� ��ġ ������ �ʿ�
        gameObject.SetActive(false);
    }
}
