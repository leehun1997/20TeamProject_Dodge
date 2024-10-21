using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ִϸ��̼� ��ȯ�� �ʿ��� ������ ������ Ŭ����
//�θ�Ŭ������ �ۿ� ������ ���� �Ļ�Ŭ������ �����
public class AnimationController : MonoBehaviour
{
    protected Animator MainSpriteAnimator;
    protected DodgeController dodgeController;//�ֻ��� ��Ʈ�ѷ��� �޾ƿ� ��������Ʈ�� �ִϸ��̼� ��� �Լ��� �������Ѿ���
    protected HealthSystem healthSystem;

    protected virtual void Awake()
    {
        //�θ������Ʈ�� ���� ã�� �ڽ��� ã��(����� �ڽ��� ã�ڴ�)
        //��ü ��������Ʈ�� ������ǿ� ��������Ʈ�� �и��Ǿ� �������� �� �� ã�ƾ��Ѵ�
        MainSpriteAnimator= GetComponentInChildren<Animator>();
        
        dodgeController = GetComponent<DodgeController>();
        healthSystem = GetComponent<HealthSystem>();
    }
}
