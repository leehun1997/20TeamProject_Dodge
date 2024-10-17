using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float currentHp;

    [Header("Health System Settings")]
    [SerializeField]private float damageApplyDelayTime = 0.5f;

    private float lastApplyTime = float.MaxValue;
    private CharacterStatHandler statHandler;

    
    public event Action OnDeath; 
    public event Action OnHeal; 
    public event Action OnDamage; 
    
    public float maxHp =>  statHandler.currentStat.characterStatSO.MaxHP;

    private void Awake()
    {
         statHandler = GetComponent<CharacterStatHandler>();
         Debug.Log(statHandler);
    }

    private void Start()
    {
        currentHp = maxHp;
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

    
    

    // Amount 값의 따라서 HP를 변경하기 위한 메서드
    public void ChangeHP(float amount)
    {
        
        Debug.Log("ChangeHP amount: " + amount); // amount 값을 출력
        currentHp = Mathf.Min(amount + currentHp , maxHp);
        
        if (currentHp <= 0)
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