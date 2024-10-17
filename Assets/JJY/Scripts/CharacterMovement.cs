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
    
    private DodgeController controller;
    private Rigidbody2D rb;
    private Vector2 direction;

    
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
        rb.velocity = direction * speed;
    }
    
}
