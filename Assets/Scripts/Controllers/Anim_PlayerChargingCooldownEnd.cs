using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Anim_PlayerChargingCooldownEnd : MonoBehaviour
{
    //애니메이션 이벤트로 사용하려면 같은 gameObject에 달려있어야 한다
    //별도의 스크립트를 달아주지 않으면 실행할 길이 없기때문에 추가 작성됨
    PlayerAnimationController PlayerAnimationController;

    private void Awake()
    {
        PlayerAnimationController = gameObject.GetComponentInParent<PlayerAnimationController>();
    }
    public void CallCooldownEnd()//애니메이션 종료 이벤트로 호출될것
    {
        PlayerAnimationController.CooldownEnd();
    }

}
