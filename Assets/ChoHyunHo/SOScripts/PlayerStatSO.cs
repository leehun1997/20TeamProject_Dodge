using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSO", menuName = "StatSO/PlayerStatSO", order = 1)]
public class PlayerStatSO : CharacterStatSO
{
    [Header("�÷��̾� ���� ����")]
    public int specialGage;
    public int playerNum;
    public string str = "���� �÷��̾� ������ ������ ����";
}
