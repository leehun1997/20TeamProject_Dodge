using UnityEngine;

public class HPPack : ConsumableItem
{
    private HealthSystem playerHP;
    
    [Header("HPPack Settings")]
    [SerializeField][Range(1,100)] private float HealAmount = 10f;
    
    protected override void Awake()
    {
        base.Awake();
        playerHP = GetComponent<HealthSystem>();
    }
    
    protected override void UseConsumableItem()
    {
        playerHP.ChangeHP(HealAmount);
    }
    
    
}