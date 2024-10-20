using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    MaxHP,
    Speed,
    BulletDamage
}


//플레이어의 스텟을 최초에 초기화만 해줄 클래스
public  abstract class CharacterStatHandler : MonoBehaviour
{
    //공통 변수
    public float  speed{ get; protected set; }
    public float maxHp { get; protected set; }
    public float damage { get; protected set;}
    public Transform target { get; protected set;}

    
    // 플레이어 , 몬스터 고유 정보를 불러올 수는 있는데 값을 변경하지는 못하는 상황 
    private CharacterStatHandler _handler; 
    
    [SerializeField] private CharacterStat characterStat;//인스펙터에서 연결 한 후 해당 캐릭터에 맞는 SO를 연결해야함
    public CharacterStat currentStat { get; protected set; }
    
    protected virtual void Awake()
    {
        InitialSetup();
    }

    protected abstract void InitialSetup();


    public virtual void UpdateStat(StatType type, float value)
    {
        switch (type)
        {
            case StatType.MaxHP:
                maxHp += value;
                break;
            case StatType.Speed:
                speed += value;
                break;
            case StatType.BulletDamage:
                //TODO DAMAGE 사용 하나로 
                currentStat.bulletSO.damage += value;
                damage += value;
                break;
        }
    }


    private void ShowDebug()
    {
        Debug.Log(gameObject.name);
        Debug.Log("초기설정 스탯SO : " + currentStat.characterStatSO);
        Debug.Log("초기설정 최대HP : " + currentStat.characterStatSO.MaxHP);
        Debug.Log("초기설정 이동속도 : " + currentStat.characterStatSO.MoveSpeed);
        Debug.Log("초기설정 총알SO : " + currentStat.bulletSO);
        Debug.Log("총알SO 타겟: " + currentStat.bulletSO.targetLayer);
        Debug.Log("총알SO 공격력 : " + currentStat.bulletSO.damage);
        Debug.Log("총알SO 크기 : " + currentStat.bulletSO.size);
        Debug.Log("총알SO 속도 : " + currentStat.bulletSO.speed);
        Debug.Log("총알SO 딜레이 : " + currentStat.bulletSO.delay);
        Debug.Log("총알SO 프리팹: " + currentStat.bulletSO.bulletPrefab);
    }
}