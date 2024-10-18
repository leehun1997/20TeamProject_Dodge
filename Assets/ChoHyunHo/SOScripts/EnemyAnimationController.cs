using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : AnimationController
{
    private int isMoving = Animator.StringToHash("isMoving");
    private int isDead = Animator.StringToHash("isDead");

    [SerializeField] private GameObject DeathAnimationPrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        dodgeController.OnMoveEvent += Move;
        //healthSystem.OnDeath += OnDeath; 사망시 애니메이션 연출 과정에서 구독시킬 필요가 없어졌다
        //사망시 DestroyOnDeath에서 사망 애니메이션만 보여줄 프리팹을 생성한다
        //사망애니메이션동안 동작하는 모든 스크립트를 끌 필요도 없고 애니메이션 속도가 달라도 대응된다
        //DestroyOnDeath에서는 사망시 바라본 방향을 가져와야 할것이다
    }

    private void Move(Vector2 v)
    {
        animator.SetBool(isMoving, v.magnitude > 0.5f);
    }
    
    //private void OnDeath()
    
}
