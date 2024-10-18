using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField][Range(0,20)]  private float speed;
    [Tooltip("accelerationTime이 클수록 더 천천히 목표 속도에 도달 ")]
    [SerializeField][Range(0,20)]  private float accelerationTime = 2.0f;  

    private DodgeController controller;
    private Rigidbody2D rb;
    private Vector2 direction;

    private Vector2 currentVelocity; // 현재 속도

    private void Awake()
    {
        controller = GetComponent<DodgeController>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        controller.OnMoveEvent += SetDircetion;
    }

    private void FixedUpdate()
    {
        Move(direction);
    }


    private void SetDircetion(Vector2 _dircetion)
    {
         direction = _dircetion;
    }
    
    
    private void Move(Vector2 direction)
    {
        rb.velocity = Vector2.Lerp(rb.velocity, direction * speed, Time.fixedDeltaTime / accelerationTime);
    }

    
    
    //테스트를 위한 메서드
    public void SetSpeedForTest(float amount)
    {
        speed += amount;
    }

}
