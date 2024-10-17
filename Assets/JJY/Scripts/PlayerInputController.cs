using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
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
        Vector3 mousePos = value.Get<Vector2>();
        Vector3 worldPos = camera.ScreenToWorldPoint(mousePos);
        
        Vector2 newAim = (worldPos - transform.position).normalized;
        Debug.Log(newAim.x + "," + newAim.y);
        CallLookEvent(newAim);
    }
    
    
}