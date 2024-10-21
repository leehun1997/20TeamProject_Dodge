using System;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent(typeof(OnDeathFragment))]
public abstract class Dropper : MonoBehaviour
{
    private OnDeathFragment onDeathFragment;

    [Header("Dropper Settings")]
    [SerializeField][Range(0,1f)]private float dropChance = 1f;
    
    protected void Awake()
    {
        onDeathFragment = GetComponent<OnDeathFragment>();
    }

    protected virtual void OnEnable()
    {
        onDeathFragment.OnDeathAnimationEnd += DrobByChance;
    }
    
    protected virtual void OnDisable()
    {
        onDeathFragment.OnDeathAnimationEnd -= DrobByChance;
    }


    private void DrobByChance()
    {
        float chance = Random.Range(0, 1f);
        if (chance <= dropChance)
            Drop();
    }

    protected abstract void Drop();
    
}

