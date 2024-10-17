using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : MonoBehaviour
{    
    private DodgeController controller;
     
    
    [Header("Aiming Settings")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    
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
     
    
    private void Look(Vector2 direction)
    {      
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //spriteRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
    
 }