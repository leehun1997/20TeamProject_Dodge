using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "BulletSO/Default", order = 0)]

public class BulletSO : ScriptableObject
{
    [Header("공통 기본 총알정보")]
    public LayerMask targetLayer;
    public float damage;
    public float size;
    public float speed;
    public float delay;

    public GameObject bulletPrefab;
    //피격 방식 총알이 Layer검사해서 참이면 damage전달
}
