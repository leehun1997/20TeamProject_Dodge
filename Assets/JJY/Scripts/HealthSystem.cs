using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

   // [Header("Health System Settings")]
   
    private CharacterStatHandler statHandler;
    
    public event Action OnDeath; 
    public event Action OnHeal; 
    public event Action OnDamage; 
    
    
    public float maxHp =>  statHandler.currentStat.characterStatSO.MaxHP;
    public float CurrentHp { get; private set; }

    private void Awake()
    {
         statHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        CurrentHp = maxHp;
    }

    
    
    //button에 넣어서 테스트 가능
    public void TestChangeHp(int num)
    {
        if (num == 0)
        {
            ChangeHP(-10f);
        }
        
        else
        {
            ChangeHP(10f);
        }
    }

    public void ChangeHP(float amount)
    {
        
        CurrentHp = Mathf.Min(amount + CurrentHp , maxHp);
        if (CurrentHp <= 0)
        {
            OnDeath?.Invoke();
        }
        else  if(amount > 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
        }
    }
    
    

 
}