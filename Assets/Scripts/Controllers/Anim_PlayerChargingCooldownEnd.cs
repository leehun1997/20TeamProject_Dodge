using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Anim_PlayerChargingCooldownEnd : MonoBehaviour
{
    //�ִϸ��̼� �̺�Ʈ�� ����Ϸ��� ���� gameObject�� �޷��־�� �Ѵ�
    //������ ��ũ��Ʈ�� �޾����� ������ ������ ���� ���⶧���� �߰� �ۼ���
    PlayerAnimationController PlayerAnimationController;

    private void Awake()
    {
        PlayerAnimationController = gameObject.GetComponentInParent<PlayerAnimationController>();
    }
    public void CallCooldownEnd()//�ִϸ��̼� ���� �̺�Ʈ�� ȣ��ɰ�
    {
        PlayerAnimationController.CooldownEnd();
    }

}
