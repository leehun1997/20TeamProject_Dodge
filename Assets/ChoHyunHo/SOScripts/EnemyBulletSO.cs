using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "BulletSO/EnemyBulletSO", order = 2)]
public class EnemyBulletSO : BulletSO
{
    [Header("적 고유 무기정보")]
    public string str = "아직 적 고유의 무기가 없음";
}
