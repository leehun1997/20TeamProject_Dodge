using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSO", menuName = "StatSO/EnemyStatSO", order = 2)]
public class EnemyStatSO : StatSO
{
    [Header("적 고유 스텟")]
    public string str = "아직 적 고유의 스텟이 없음";
}
