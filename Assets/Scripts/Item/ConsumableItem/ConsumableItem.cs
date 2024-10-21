using System;

public abstract class ConsumableItem : Item
{

    public override void UseItem()
    {
        UseConsumableItem();
        AudioManager.Instance.PlaySfx("Pickup");
    }
    
    protected abstract void UseConsumableItem();

}