using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<BulletSO> OnAttackEvent;
    protected bool isAttacking { get; set; }

    

    protected virtual void Awake()
    {

    }

    private void Update()
    {

    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); //?. ������ ���� ������ ����
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    private void CallAttackEvent(BulletSO attackSO)
    {
       OnAttackEvent?.Invoke(attackSO);
    }
}



