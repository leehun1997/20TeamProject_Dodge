using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    private int isMoving = Animator.StringToHash("isMoving");
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        dodgeController.OnMoveEvent += Move;
    }

    private void Move(Vector2 v)
    {
        animator.SetBool(isMoving, v.magnitude > 0.5f);
    }
}
