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
        //보간 적용 , Time.fixedDeltaTime / accelerationTime 계수만 큼 보간    흐른 시간 / 2f
        rb.velocity = Vector2.Lerp(rb.velocity, direction * speed, Time.fixedDeltaTime / accelerationTime);
    }
    
}
