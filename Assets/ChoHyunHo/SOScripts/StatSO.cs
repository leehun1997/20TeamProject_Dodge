using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSO", menuName = "StatSO/Default", order = 0)]

//���� �⺻���� ���� �� �ӵ�
public class StatSO : ScriptableObject
{
    [Header("���� �⺻ ����")]
    public float MaxHP;
    public float MoveSpeed;
}



