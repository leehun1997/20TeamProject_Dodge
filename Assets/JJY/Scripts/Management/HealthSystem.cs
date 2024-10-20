using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

   // [Header("Health System Settings")]
   
    private CharacterStatHandler statHandler;
    
    public event Action OnDeath; 
    public event Action OnHeal; 
    public event Action OnDamage; 
    
    
    public float maxHp =>  statHandler.maxHp;

    public float CurrentHp { get; private set; }

    public Slider healthSlider; //슬라이더를 인스펙터에서 가져옴
    [SerializeField] private bool isPlayer; // 플레이어 여부 확인

    private void Awake()
    {
         statHandler = GetComponent<CharacterStatHandler>();
         Debug.Log(statHandler);
    }

    
    private void Start()
    {
        CurrentHp = maxHp;

        if(isPlayer&&healthSlider != null)
        {
            healthSlider.maxValue = maxHp;
            healthSlider.value = CurrentHp;
        }
    }

    
    
    //button에 넣어서 테스트 가능
    public void TestChangeHp(int num)
    {
       
        if (num == 0)
        {
            ChangeHP(-1f);
            Debug.Log("데미지 1");        
        }
        
        else
        {
            ChangeHP(10f);
        }
    }

    public void ChangeHP(float amount)
    {
        
        CurrentHp = Mathf.Min(amount + CurrentHp , maxHp);
        Debug.Log($"{amount} / {CurrentHp}");
        // 플레이어의 경우에만 슬라이더 업데이트
        if (isPlayer && healthSlider != null)
        {
            healthSlider.value = CurrentHp;
        }

        if (CurrentHp <= 0)
        {
            
            Debug.Log("온데스");
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