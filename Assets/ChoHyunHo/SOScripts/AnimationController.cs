using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//애니메이션 전환에 필요한 변수만 전달할 클래스
//부모클래스로 작용 유형에 따라 파생클래스가 생길것
public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected DodgeController dodgeController;//최상위 컨트롤러로 받아와 델리게이트에 애니메이션 출력 함수를 구독시켜야함
    //Delegate? Invoke();시 움직이는함수 + 애니메이션바꾸는함수 같이 실행될것임

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        dodgeController = GetComponent<DodgeController>();
    }
}
