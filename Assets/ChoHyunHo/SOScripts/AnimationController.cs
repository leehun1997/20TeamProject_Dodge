using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ִϸ��̼� ��ȯ�� �ʿ��� ������ ������ Ŭ����
//�θ�Ŭ������ �ۿ� ������ ���� �Ļ�Ŭ������ �����
public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected DodgeController dodgeController;//�ֻ��� ��Ʈ�ѷ��� �޾ƿ� ��������Ʈ�� �ִϸ��̼� ��� �Լ��� �������Ѿ���
    protected HealthSystem healthSystem;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        dodgeController = GetComponent<DodgeController>();
        healthSystem = GetComponent<HealthSystem>();
    }
}
