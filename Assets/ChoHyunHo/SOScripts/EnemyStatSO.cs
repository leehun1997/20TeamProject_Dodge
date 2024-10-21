using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatSO", menuName = "StatSO/EnemyStatSO", order = 2)]
public class EnemyStatSO : CharacterStatSO
{
    [Header("적 고유 스텟")]
    public string str = "아직 적 고유 스텟이 없음";
}

