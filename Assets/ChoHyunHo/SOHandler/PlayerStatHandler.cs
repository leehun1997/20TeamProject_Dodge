using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어의 스텟을 최초에 초기화만 해줄 클래스
public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] private PlayerStatSO baseStatSO;
    [SerializeField] private PlayerBulletSO baseBulletSO;

    //아무나 조회가능 세팅은 이 클래스만
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


