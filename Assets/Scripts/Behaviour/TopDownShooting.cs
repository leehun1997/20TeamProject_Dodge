using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private DodgeController controller;
    [SerializeField] private Transform BulletSpawnPoint;
    private Vector2 shootDirection = Vector2.up;

    private ObjectPool pool;


    private void Awake()
    {
        controller = GetComponent<DodgeController>();
        if (controller == null) controller = GetComponentInParent<DodgeController>();
        pool = GameObject.FindObjectOfType<ObjectPool>();
    }

    private void Start()
    {
        controller.OnLookEvent += Aim2;
        controller.OnAttackEvent += Shooting;
    }

    private void Shooting(BulletSO bulletSO)
    {
        BulletSO bSO = bulletSO as BulletSO;
        if (bulletSO == null) return;
        if(CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("Shoot");
        }
        CreateProjectile(bSO);
    }

    private void Aim2(Vector2 direction)//���� �޾ƿ���
    {
        shootDirection = direction;
    }

    private void CreateProjectile(BulletSO bulletSO)
    {
        GameObject b = pool.SpawnFromPool(bulletSO.bulletNameTag);
        b.transform.position = BulletSpawnPoint.transform.position;
        b.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);

        ProjectileController attackController = b.GetComponent<ProjectileController>();
        attackController.InitiateAttack(shootDirection, bulletSO); //�⺻ ���ݸ� �ִٰ� ����, ������ ������ �������� ����
    }
}
