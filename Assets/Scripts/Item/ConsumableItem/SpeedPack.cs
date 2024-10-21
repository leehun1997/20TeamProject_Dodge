using UnityEngine;

public class SpeedPack : ConsumableItem
{
    
    [Header("SpeedPack Settings")] 
    [SerializeField] [Range(1, 10)] private float speedUp = 10f;

    
    protected override void UseConsumableItem()
    {
        playerStat.UpdateStat(StatType.Speed,speedUp);
        Destroy(gameObject);
    }
    
}