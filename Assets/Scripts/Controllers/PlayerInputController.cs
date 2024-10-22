﻿using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerInputController : DodgeController
{
    private Camera camera;
    
    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main;
    }
        
    public void OnMove(InputValue value)
     {       
          Vector2 moveInput = value.Get<Vector2>().normalized;
          CallMoveEvent(moveInput);
     }

    public void OnPause(InputValue value)
    {
        CallPauseEvent();
    }

     
    
    public void OnLook(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);
        Vector2 newAim = (worldPos - (Vector2)transform.position).normalized;
        CallLookEvent(newAim);
    }

    public void OnLeftMouse(InputValue value)
    {
        isAttacking = value.isPressed;
    }
    public void OnRightMouse(InputValue value)
    {
        if(value.isPressed)//占쏙옙占쏙옙占쏙옙
        {
            isCharging= true;
            Debug.Log("Charging");            
        } 
        else if(value.isPressed == false && isCharging == true)//player1의 특수 공격
        {
            isCharging= false;
            if (chargeGage == 0) return;

            Debug.Log("Special Attack" + chargeGage);
            CallChargeAttackEvent(statHandler.currentStat.specialBulletSO,isCharging, chargeGage);
            currentGage -= (int)chargeGage;
            chargeGage= 0f;
        }
    }
}