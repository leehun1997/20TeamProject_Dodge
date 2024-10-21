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

    

    public void ChangeHP(float amount)
    {
        
        CurrentHp = Mathf.Min(amount + CurrentHp , maxHp);
 
        if (isPlayer && healthSlider != null)
        {
            healthSlider.value = CurrentHp;
        }

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
            
            //TODO 파편 HIT 처리 할건지?
            if(CurrentHp >0)
               AudioManager.Instance.PlaySfx("Hit");
        }
    }
    
    

 
}