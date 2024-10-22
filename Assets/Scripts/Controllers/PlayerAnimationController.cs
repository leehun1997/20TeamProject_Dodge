using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerAnimationController : AnimationController
{
    private Animator ChargeAnimator;//�÷��̾�� �ִ� ������������Ʈ �ִϸ�����

    private int isMoving = Animator.StringToHash("isMoving");
    private int isCharge = Animator.StringToHash("isCharge");
    private int isCooldown = Animator.StringToHash("isCooldown");//�������� �� ��ٿ� �ִϸ��̼ǵ��� �ٽ� �������� ��� ���� ���� ���´�

    private int isHit = Animator.StringToHash("isHit");

    protected override void Awake()
    {
        //�� ��ũ��Ʈ�� ���� ���ӿ�����Ʈ�� �ڽĵ��� Ž���Ѵ�
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

    
    public void ChargeAnimation(bool isCharging)//��Ŭ�� ������, ������
    {
        //TopDownCharginging���� ȣ�� inputSystem�� ���� ��Ŭ������, �������� true�� ��� ������ ���¼��� false�� ���´�
        ChargeAnimator.SetBool(isCharge, isCharging);
        //�ִϸ����� Ʈ�������� ���ǿ� ���� �ִϸ��̼��� ���� �ȴ�

        if (isCharging == false)//��Ŭ�� ������ false�� ���� ���̴�
        {
            CooldownStart();//��Ŭ���� ������(���������� ������)
        }
    }

    public void CooldownStart()//����� ���� ChargeAnimation()���� ȣ�� 
    {
        ChargeAnimator.SetBool(isCooldown, true);
    }

    public void CooldownEnd()//Anim_PlayerChargingCooldownEnd.cs���� ȣ��ɰ�
    {
        ChargeAnimator.SetBool(isCooldown, false);
        Debug.Log(isCooldown);
    }
   
    private void Hit()//healthSystem.OnDamage ������
    {
        MainSpriteAnimator.SetBool(isMoving, false);
        MainSpriteAnimator.SetTrigger(isHit);
    }

}
