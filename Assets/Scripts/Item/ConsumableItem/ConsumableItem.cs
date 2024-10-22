using System;

public abstract class ConsumableItem : Item
{

    public override void UseItem()
    {
        UseConsumableItem();
        AudioManager.Instance.PlaySFX("Pickup");
    }
    
    protected abstract void UseConsumableItem();

}