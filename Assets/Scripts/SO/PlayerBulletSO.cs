using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "BulletSO/PlayerBulletSO", order = 1)]
public class PlayerBulletSO : BulletSO
{
    [Header("�÷��̾� ���� ��������")]
    public float bulletDuration;
    public float bulletDelay;
    public string str = "���� �÷��̾� ������ ���Ⱑ ����";
}
