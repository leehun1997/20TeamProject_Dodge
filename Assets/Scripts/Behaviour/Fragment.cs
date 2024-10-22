using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Fragment : MonoBehaviour
{
    HealthSystem healthSystem;

    Rigidbody2D rb2D;

    [SerializeField] private LayerMask levelCollisionLayer;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        healthSystem.OnDeath += OnDestroyMe;
        Push();
    }

    private void Push()
    {
        //TransformDirection유니티 제공 로컬방향>월드방향으로 돌려주는 Vector2.right가 2D기준 정면
        //너무쌔서/2
        rb2D.AddForce(transform.TransformDirection(Vector2.right) / 4, ForceMode2D.Impulse);
    }

    //유니티에서 이미 제공하는 메서드들은 이벤트 구독자로 사용 하면 문제가 생길 수 있음, 

    private void OnDestroyMe() // 파괴됐을 때 생기는 함수 
    {
        gameObject.GetComponentInParent<OnDeathFragment>().FragmentDisable();
        Destroy(this.gameObject);
    }

    private bool IsLayerMatched(int value, int layer) //���̾� ����ũ�� 2���� ���������� 2������ �ƴϴ�. 
    {
        return
            value == (value |
                      1 << layer); //���� ���ϴ� ��ȣ�� ���̾� ����ũ���� Ȯ��, �ٸ� ���̾�� �Ҽ����� ���� �ƴ��� �� �� ����
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsLayerMatched(levelCollisionLayer.value, collision.gameObject.layer))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Push();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsLayerMatched(levelCollisionLayer.value, collision.gameObject.layer))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            OnDestroyMe();
        }
    }
}