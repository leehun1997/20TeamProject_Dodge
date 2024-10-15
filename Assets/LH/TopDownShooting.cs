using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;
    private GameObject AttackPrefab;
    private GameObject BulletSpawnPoint;

    private void Awake()
    {
        controller= GetComponent<TopDownController>();
    }

    private void Start()
    {
        //controller.CallMoveEvent += ;
        //controller.CallLookEvent += ;
        //controller.CallAttackEvent +=;
    }

    //private void Shooting(BulletSO bulletSO)
    //{
    //    BulletSO bulletSO = bulletSO as BulletSO; 
    //    if (bulletSO == null) return;
    //
    //    CreateProjectile(bulletSo);
    //}

    //private void CreateProjectile(BulletSO bulletSO)
    //{
    //    Instantiate(bulletSO.bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.Euler(0,0,0));
    //}
}
