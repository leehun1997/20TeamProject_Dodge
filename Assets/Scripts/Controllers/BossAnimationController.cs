using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : AnimationController
{
    private int isMoving = Animator.StringToHash("isMoving");
    [SerializeField] private Boss1Controller boss1Controller;

    private int isHit = Animator.StringToHash("isHit");

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        dodgeController.OnMoveEvent += Move;

        if (healthSystem != null)
        {
            healthSystem.OnDamage += Hit;
        }
        //dodgeController.OnEvent += Launch;
        //healthSystem.OnDeath += OnDeath; 사망시 애니메이션 연출 과정에서 구독시킬 필요가 없어졌다
        //사망시 DestroyOnDeath에서 사망 애니메이션만 수행할 객체를 생성한다
        //사망애니메이션동안 동작하는 모든 스크립트를 끌 필요도 없고 애니메이션 속도가 달라도 대응된다
        //DestroyOnDeath에서는 사망시 바라본 방향을 가져와야 할것이다
    }

    private void Move(Vector2 v)
    {
        MainSpriteAnimator.SetBool(isMoving, v.magnitude > 0.5f);
    }

    private void Hit()//healthSystem.OnDamage 구독중
    {
        MainSpriteAnimator.SetBool(isMoving, false);
        MainSpriteAnimator.SetTrigger(isHit);
    }

}
