using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "BulletSO/PlayerBulletSO", order = 1)]
public class PlayerBulletSO : BulletSO
{
    [Header("플레이어 고유 무기정보")]
    public float bulletDuration;
    public float bulletDelay;
    public string str = "아직 플레이어 고유의 무기가 없음";
}
