using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    private Animator ChargeAnimator;//플레이어에만 있는 차지스프라이트 애니메이터

    private int isMoving = Animator.StringToHash("isMoving");

    private int isCharge = Animator.StringToHash("isCharge");
    private int isShoot = Animator.StringToHash("isShoot");

    protected override void Awake()
    {
        MainSpriteAnimator = GameObject.Find(this.gameObject.name).transform.Find("PlayerSpirte").GetComponent<Animator>();
        ChargeAnimator = GameObject.Find(this.gameObject.name).transform.Find("ChargeSprite").GetComponent<Animator>();

        dodgeController = GetComponent<DodgeController>();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        dodgeController.OnMoveEvent += Move;
        //dodgeController.StartChargeEvent += StartCharge;
        //dodgeController.StartEndEvent += EndCharge;
    }

    private void Move(Vector2 v)
    {
        MainSpriteAnimator.SetBool(isMoving, v.magnitude > 0.5f);
    }

    private void StartCharge()//우클릭 했을때
    {
        ChargeAnimator.SetBool(isCharge, true);
    }

    private void EndCharge()//우클릭 땟을때
    {
        ChargeAnimator.SetBool(isShoot, true);
    }
}
