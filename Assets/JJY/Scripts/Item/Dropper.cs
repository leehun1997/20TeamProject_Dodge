using System;
using UnityEngine;


[RequireComponent(typeof(OnDeathFragment))]
public abstract class Dropper : MonoBehaviour
{
    private OnDeathFragment onDeathFragment;
 
    
    protected void Awake()
    {
        onDeathFragment = GetComponent<OnDeathFragment>();
    }

    protected virtual void OnEnable()
    {
        onDeathFragment.OnDeathAnimationEnd += Drop;
    }
    
    protected virtual void OnDisable()
    {
        onDeathFragment.OnDeathAnimationEnd -= Drop;
    }
    
    
     
    
    protected abstract void Drop();
    
}

