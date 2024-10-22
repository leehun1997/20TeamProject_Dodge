using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerAnimationController : AnimationController
{
    private Animator ChargeAnimator;//플레이어에만 있는 차지스프라이트 애니메이터

    private int isMoving = Animator.StringToHash("isMoving");
    private int isCharge = Animator.StringToHash("isCharge");
    private int isCooldown = Animator.StringToHash("isCooldown");//차지공격 후 쿨다운 애니메이션동안 다시 차지공격 모션 들어가는 것을 막는다

    private int isHit = Animator.StringToHash("isHit");

    protected override void Awake()
    {
        //이 스크립트가 붙은 게임오브젝트의 자식들을 탐색한다
        MainSpriteAnimator = GameObject.Find(this.gameObject.name).transform.Find("PlayerSpirte").GetComponent<Animator>();
        ChargeAnimator = GameObject.Find(this.gameObject.name).transform.Find("ChargeSprite").GetComponent<Animator>();

        dodgeController = GetComponent<DodgeController>();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        dodgeController.OnMoveEvent += Move;

        if (healthSystem != null)
        {
            healthSystem.OnDamage += Hit;
        }
    }

    private void Move(Vector2 v)
    {
        MainSpriteAnimator.SetBool(isMoving, v.magnitude > 0.5f);
    }

    
    public void ChargeAnimation(bool isCharging)//우클릭 했을때, 땟을때
    {
        //TopDownCharginging에서 호출 inputSystem에 의해 우클릭시작, 지속중은 true를 계속 들어오고 때는순간 false가 들어온다
        ChargeAnimator.SetBool(isCharge, isCharging);
        //애니메이터 트랜지스터 조건에 따라 애니메이션이 실행 된다

        if (isCharging == false)//우클릭 땠을때 false가 들어올 것이다
        {
            CooldownStart();//우클릭을 땠을때(차지공격을 쐈을때)
        }
    }

    public void CooldownStart()//쏘고나서 위의 ChargeAnimation()에서 호출 
    {
        ChargeAnimator.SetBool(isCooldown, true);
    }

    public void CooldownEnd()//Anim_PlayerChargingCooldownEnd.cs에서 호출될것
    {
        ChargeAnimator.SetBool(isCooldown, false);
        Debug.Log(isCooldown);
    }
   
    private void Hit()//healthSystem.OnDamage 구독중
    {
        MainSpriteAnimator.SetBool(isMoving, false);
        MainSpriteAnimator.SetTrigger(isHit);
    }

}
