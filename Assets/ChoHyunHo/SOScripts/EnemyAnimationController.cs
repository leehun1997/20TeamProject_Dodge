using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : AnimationController
{
    private int isMoving = Animator.StringToHash("isMoving");
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        //dodgeController.OnMoveEvent += Move;
    }

    private void Move()
    {
        animator.SetBool(isMoving, true);
    }
}