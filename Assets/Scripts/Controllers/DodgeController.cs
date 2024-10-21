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

    protected CharacterStatHandler statHandler { get; set; }

    protected virtual void Awake()
    {
        statHandler = GetComponent<CharacterStatHandler>();
    }

    protected virtual void Start()
    {
        statHandler = GetComponent<CharacterStatHandler>();
        currentGage = statHandler.currentStat.characterStatSO.MaxGage;
    }

    protected virtual void Update()
    {
        if (isAttacking && delayTime <= 0)
        {
            delayTime = statHandler.currentStat.bulletSO.delay;
            CallAttackEvent(statHandler.currentStat.bulletSO);
        }
        else
        {
            delayTime -= Time.deltaTime;
        }
        if (isCharging)
        {
            if (currentGage <= 0)
            {
                Debug.Log($"Can't Use SpecialAttack! {chargeGage} {currentGage}");
                return;
            }

            else if (chargeGage >= currentGage)
            {
                Debug.Log("Full Charge!");
                chargeGage = currentGage;
                CallChargeAttackEvent(statHandler.currentStat.bulletSO, isCharging, chargeGage);
            }
            else
            {
                chargeGage += Time.deltaTime;
                CallChargeAttackEvent(statHandler.currentStat.bulletSO, isCharging, chargeGage);
            }
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
    public void CallChargeAttackEvent(BulletSO attackSO,bool charging,double chargeGage)
    {
        OnChargeEvent?.Invoke(attackSO,charging,chargeGage);
    }
}



