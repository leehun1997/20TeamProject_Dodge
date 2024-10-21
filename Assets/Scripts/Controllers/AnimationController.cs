using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//애니메이션 전환에 필요한 변수만 전달할 클래스
//부모클래스로 작용 유형에 따라 파생클래스가 생길것
public class AnimationController : MonoBehaviour
{
    protected Animator MainSpriteAnimator;
    protected DodgeController dodgeController;//최상위 컨트롤러로 받아와 델리게이트에 애니메이션 출력 함수를 구독시켜야함
    protected HealthSystem healthSystem;

    protected virtual void Awake()
    {
        //부모오브젝트를 먼저 찾고 자식을 찾음(어딘가의 자식을 찾겠다)
        //몸체 스프라이트와 차지모션용 스프라이트가 분리되어 있음으로 둘 다 찾아야한다
        MainSpriteAnimator= GetComponentInChildren<Animator>();
        
        dodgeController = GetComponent<DodgeController>();
        healthSystem = GetComponent<HealthSystem>();
    }
}
