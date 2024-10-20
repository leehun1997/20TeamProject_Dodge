using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentPush : MonoBehaviour
{
    Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Push();
    }

    private void Push()
    {
        //TransformDirection����Ƽ ���� ������ǥ>������ǥ Vector2������ ������ x���(����ȭ��ǥ)�̴� Vector2.right�� 2D������ ����
        //�ʹ� �ؼ� / 2
        rb2D.AddForce(transform.TransformDirection(Vector2.right) / 2, ForceMode2D.Impulse);
    }



}
