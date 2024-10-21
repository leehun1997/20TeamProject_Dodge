using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParentStatSO", menuName = "StatSO/Default", order = 0)]

//가장 기본적인 스텟 피 속도
public class CharacterStatSO : ScriptableObject
{
    [Header("공통 기본 스텟")]
    public float MaxHP = 10;
    public float MoveSpeed;
    public int MaxGage;
}



