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
        //dodgeController.OnMoveEvent += Move;
        Move();
    }

    private void Move()
    {
        animator.SetBool(isMoving, true);
    }
}
