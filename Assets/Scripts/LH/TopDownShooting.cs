using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private DodgeController controller;
    [SerializeField] private Transform BulletSpawnPoint;
    private Vector2 shootDirection = Vector2.up;

    private void Awake()
    {
        controller = GetComponent<DodgeController>();
    }

    private void Start()
    {
        //controller.CallLookEvent += Aim;
        //controller.CallAttackEvent +=Shooting;
    }

    //private void Shooting(BulletSO bulletSO)
    //{
    //    BulletSO bulletSO = bulletSO as BulletSO; 
    //    if (bulletSO == null) return;
    //
    //    CreateProjectile(bulletSo);
    //}

    //private void Aim(Vector2 direction)//���� �޾ƿ���
    //{
    //    shootDirection = direction;
    //}

    //private void CreateProjectile(BulletSO bulletSO)
    //{
    //    GameObject b = Instantiate(bulletSO.bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity);
    //    ProjectileController attackController = b.GetComponent<ProjectileController>();
    //    attackController.InitiateAttack(shootDirection); //�⺻ ���ݸ� �ִٰ� ����, ������ ������ �������� ����
    //}
}