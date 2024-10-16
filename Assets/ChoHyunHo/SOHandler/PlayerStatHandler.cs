using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾��� ������ ���ʿ� �ʱ�ȭ�� ���� Ŭ����
public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] private PlayerStatSO baseStatSO;
    [SerializeField] private PlayerBulletSO baseBulletSO;

    //�ƹ��� ��ȸ���� ������ �� Ŭ������
    public PlayerStat currentStat { get; private set; }

    private void Awake()
    {
        InitialSetup();
    }

    private void InitialSetup()
    {
        currentStat = new PlayerStat();
        currentStat.MaxHP = baseStatSO.MaxHP;
        currentStat.MoveSpeed = baseStatSO.MoveSpeed;
        currentStat.bulletSO = baseBulletSO;
    }
}


