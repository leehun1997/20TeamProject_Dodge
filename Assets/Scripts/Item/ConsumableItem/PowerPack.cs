using UnityEngine;

public class PowerPack : ConsumableItem
{
    [Header("PowerPack Settings")] 
    [SerializeField] [Range(1, 10)] private float powerUP = 10f;

  
    
    protected override void UseConsumableItem()
    {
        playerStat.UpdateStat(StatType.BulletDamage, powerUP);
        gameObject.SetActive(false);
    }
    
}