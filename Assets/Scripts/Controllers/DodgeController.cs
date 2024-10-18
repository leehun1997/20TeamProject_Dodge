using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<BulletSO> OnAttackEvent;
    public event Action<BulletSO,double> OnChargeEvent;
    protected bool isAttacking { get; set; }
    protected bool isCharging { get; set; }

    private float delayTime = 0f;

    protected int currentGage;
    protected double chargeGage = 0;

    protected CharacterStatHandler statHandler { get; set; }

    protected virtual void Awake()
    {
        
    }

    protected virtual void Start()
    {
        statHandler = GetComponent<CharacterStatHandler>();
        currentGage = statHandler.currentStat.characterStatSO.MaxGage;
    }

    protected virtual void Update()
    {
        if (isCharging)//차지중이면 공격불가로 만들기
        {
            if (currentGage <= 0) 
            { 
                Debug.Log("Can't Use SpecialAttack!"); 
                return; 
            }
            else  if (chargeGage >= currentGage)
            {
                Debug.Log($"Full Charge! {chargeGage} {currentGage}");
                chargeGage = currentGage;
            }
            else
                chargeGage += Time.deltaTime;
        }

        if (isAttacking && delayTime <= 0)
        {
            delayTime = statHandler.currentStat.bulletSO.delay;
            CallAttackEvent(statHandler.currentStat.bulletSO);
        }
        else
        {
            delayTime -= Time.deltaTime;
        }
    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); //?. ������ ���� ������ ����
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallAttackEvent(BulletSO attackSO)
    {
       OnAttackEvent?.Invoke(attackSO);
    }
    public void CallChargeAttackEvent(BulletSO attackSO,double chargeGage)
    {
        OnChargeEvent?.Invoke(attackSO,chargeGage);
    }
}



