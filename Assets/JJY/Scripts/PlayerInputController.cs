using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
     
     void OnMove(InputValue value)
    {
        Debug.Log("키보드 눌림");
        //Vector2 moveInput = value.Get<Vector2>().normalized;
       // CallMoveEvent(moveInput);
    }

    void OnLook(InputValue value)
    {
        Debug.Log("마우스 눌림");
    }


}