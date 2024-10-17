using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : DodgeController
{
    private Camera camera;
    
    private bool pressed = false;

    public BulletSO bulletSO;
    
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

    public void OnFire(InputValue value)
    {
        isAttacking = value.isPressed;
    }
    
}