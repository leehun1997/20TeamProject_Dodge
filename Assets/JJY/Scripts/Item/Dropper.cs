using System;
using UnityEngine;


[RequireComponent(typeof(HealthSystem))]
public abstract class Dropper : MonoBehaviour
{
    private HealthSystem healthSystem;
 
    
    protected void Awake()
    {
          healthSystem = GetComponent<HealthSystem>();
    }

    protected virtual void OnEnable()
    {
        healthSystem.OnDeath += Drop;
    }
    
    protected virtual void OnDisable()
    {
        healthSystem.OnDeath -= Drop;
    }
    
    
    protected abstract void Drop();
    
}

