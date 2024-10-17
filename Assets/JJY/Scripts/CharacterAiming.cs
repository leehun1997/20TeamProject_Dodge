using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : MonoBehaviour
{    
    private DodgeController controller;

    
    [Header("Aiming Settings")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float rotationSpeed = 5f;

    private void Awake()
    {
        controller = GetComponent<DodgeController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    void Start()
    {
        controller.OnLookEvent += OnAim;
    }
    
    private void OnAim(Vector2 direction)
    {
        Look(direction);
    }
     
    
    // private void Look(Vector2 direction)
    // {      
    //     float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //     transform.rotation = Quaternion.Euler(0,0,angle);
    // }
    
    private void Look(Vector2 direction)
    {
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    
 }