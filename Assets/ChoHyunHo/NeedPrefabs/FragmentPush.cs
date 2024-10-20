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
        //TransformDirection유니티 제공 월드좌표>로컬좌표 Vector2에서의 정면은 x축→(빨간화살표)이다 Vector2.right가 2D에서의 정면
        //너무 쌔서 / 2
        rb2D.AddForce(transform.TransformDirection(Vector2.right) / 2, ForceMode2D.Impulse);
    }



}
