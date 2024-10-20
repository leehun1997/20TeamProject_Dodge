using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Fragment : MonoBehaviour
{
    HealthSystem healthSystem;

    Rigidbody2D rb2D;


    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        healthSystem.OnDeath += OnDestroy;
        Push();
    }

    private void Push()
    {
        //TransformDirection����Ƽ ���� ������ǥ>������ǥ Vector2������ ������ x���(����ȭ��ǥ)�̴� Vector2.right�� 2D������ ����
        //�ʹ� �ؼ� / 2
        rb2D.AddForce(transform.TransformDirection(Vector2.right) / 2, ForceMode2D.Impulse);
    }
    private void OnDestroy()
    {
        gameObject.GetComponentInParent<OnDeathFragment>().FragmentDisable();
        gameObject.SetActive(false);
    }

}
