using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<BulletSO> OnAttackEvent;
    public event Action<BulletSO,bool,double> OnChargeEvent;
    protected bool isAttacking { get; set; }
    protected bool isCharging { get; set; }

    private float delayTime = 0f;

    protected int currentGage;
    protected double chargeGage = 0;

    protected PlayerStatHandler statHandler { get; set; }

    protected virtual void Awake()
    {
        statHandler = GetComponent<PlayerStatHandler>();
    }

    protected virtual void Start()
    {        
        currentGage = (int)statHandler.gage;
    }

    protected virtual void Update()
    {
        if (isCharging)//차지중이면 공격불가로 만들기?
        {
            if (currentGage <= 0)
            {
                Debug.Log($"Can't Use SpecialAttack! {currentGage} {chargeGage}");
                return;
            }
            else if (chargeGage >= currentGage)
            {
                Debug.Log($"Full Charge! {chargeGage} {currentGage}");
                chargeGage = currentGage;
                CallChargeAttackEvent(statHandler.basePlayerBulletSO, isCharging, chargeGage);
            }
            else
            {
                chargeGage += Time.deltaTime;
                CallChargeAttackEvent(statHandler.basePlayerBulletSO, isCharging, chargeGage);
            }
        }

        if (isAttacking && delayTime <= 0)
        {
            delayTime = statHandler.currentStat.bulletSO.delay;
            CallAttackEvent(statHandler.basePlayerBulletSO);
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
    public void CallChargeAttackEvent(BulletSO attackSO, bool isCharging,double chargeGage)
    {
        OnChargeEvent?.Invoke(attackSO,isCharging,chargeGage);
    }
}



