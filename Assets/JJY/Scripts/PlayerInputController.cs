using UnityEngine;
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
        if(value.isPressed)//������
        {
            isCharging= true;
            Debug.Log("Charging");
        } 
        else if(value.isPressed == false && isCharging == true)//player1�� Ư�� ����
        {
            isCharging= false;
            if (chargeGage == 0) return;

            Debug.Log("Special Attack1" + chargeGage);
            CallChargeAttackEvent(statHandler.currentStat.bulletSO, chargeGage);
            currentGage -= (int)chargeGage;
            chargeGage= 0;
        }
        else if (isCharging == true)//player2�� Ư�� ����, ���� �߰� �ʿ�
        {
            Debug.Log("Special Attack2" + chargeGage);
            CallChargeAttackEvent(statHandler.currentStat.bulletSO, currentGage);
        }
    }
}