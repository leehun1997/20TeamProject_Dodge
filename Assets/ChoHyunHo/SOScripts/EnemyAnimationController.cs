using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : AnimationController
{
    private int isMoving = Animator.StringToHash("isMoving");
    private int isDead = Animator.StringToHash("isDead");
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        dodgeController.OnMoveEvent += Move;
        healthSystem.OnDeath += OnDeath;
    }

    private void Move(Vector2 v)
    {
        animator.SetBool(isMoving, v.magnitude > 0.5f);
    }

    private void OnDeath()
    {
        animator.SetBool(isDead, true);
    }
}
