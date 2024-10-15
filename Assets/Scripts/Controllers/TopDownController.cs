using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    //public event Action<AttackSO> OnAttackEvent;
    protected bool isAttacking { get; set; }

    

    protected virtual void Awake()
    {

    }

    private void Update()
    {

    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); //?. 없으면 무시 있으면 실행
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    //private void CallAttackEvent(AttackSO attackSO)
    //{
    //    OnAttackEvent?.Invoke(attackSO);
    //}
}
