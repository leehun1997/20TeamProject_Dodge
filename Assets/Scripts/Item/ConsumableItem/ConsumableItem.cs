using System;

public abstract class ConsumableItem : Item
{

    public override void UseItem()
    {
        UseConsumableItem();
    }
    
    protected abstract void UseConsumableItem();

}