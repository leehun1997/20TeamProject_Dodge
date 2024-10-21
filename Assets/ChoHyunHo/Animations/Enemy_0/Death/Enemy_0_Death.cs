using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_0_Death : MonoBehaviour
{
    [Header("ĳ���� ������ �´� ������ �ڽ�ȭ �� �� ���")]
    [SerializeField] List<GameObject> fragments;

    private SpriteRenderer SpriteRenderer;

    private float RandNum;
    private Vector2 makePosition;

    private void Awake()
    {
        SpriteRenderer=GetComponent<SpriteRenderer>();
    }

    //Enemy_0_Death�ִϸ�����>Death�ִϸ��̼�>Add Animation Event���� ȣ���
    public void DeathAnimationEnd()
    {
        //�ִϸ��̼� ���� > ������ �ڱ� sprite��Ȱ��ȭ �ڽĵ� Ȱ��ȭ
        //������ƮǮ ���� �ڽĲ��� �ڱ� sprite�ѱ�
        //�ڽ� ���÷����̼� �ٲٱ� ������Ʈ Ǯ�� �ʿ��ϴ�

        SpriteRenderer.enabled = false;
        foreach (var obj in fragments)
        {
            RandNum = Random.Range(0f, 360f);
            obj.SetActive(true);
            obj.transform.localRotation = Quaternion.Euler(0, 0, RandNum);

            //������ ��ũ��Ʈ�� ó�� ���⼭�� �۵���������
            //objRigid2D = obj.GetComponent<Rigidbody2D>();
            //objRigid2D.AddForce(transform.TransformDirection(Vector2.right) / 2, ForceMode2D.Impulse);
        }
        
    }

    //������(������ƮǮ�� ����) SpriteRenderer.enabled = 

}
