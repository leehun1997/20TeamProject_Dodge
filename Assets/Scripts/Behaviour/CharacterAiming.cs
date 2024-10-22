using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : MonoBehaviour
{    
    private DodgeController controller;

    
    [Header("Aiming Settings")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField][Tooltip("rotationSpeed값이 클수록 회전 속도 빨라짐")] private float rotationSpeed = 5f;

    private void Awake()
    {
        controller = GetComponent<DodgeController>();
        //if (controller == null) controller = GetComponentInParent<DodgeController>();//보스일때 

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();//보스일때 
    }
    
    void Start()
    {
        controller.OnLookEvent += OnAim;
    }
    
    private void OnAim(Vector2 direction)
    {
        Look(direction);
    }
    
    private void Look(Vector2 direction)
    {
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    
 }