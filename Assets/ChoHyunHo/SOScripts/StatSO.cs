using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSO", menuName = "StatSO/Default", order = 0)]

//가장 기본적인 스텟 피 속도
public class StatSO : ScriptableObject
{
    [Header("공통 기본 스텟")]
    public float MaxHP;
    public float MoveSpeed;
}



