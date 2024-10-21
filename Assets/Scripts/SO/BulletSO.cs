using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "BulletSO/Default", order = 0)]

public class BulletSO : ScriptableObject
{
    [Header("공통 기본 총알정보")]
    public string bulletNameTag;
    public LayerMask targetLayer;
    public float damage;
    public float size;
    public float speed;
    public float delay;
    public float duration;//몇초 후 투사체 파괴

    public GameObject bulletPrefab;
    public GameObject specialbulletPrefab;
    //피격 방식 총알이 Layer검사해서 참이면 damage전달
}
