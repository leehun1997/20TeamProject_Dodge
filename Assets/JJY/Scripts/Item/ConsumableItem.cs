public abstract class ConsumableItem : Item
{
    protected override void UseItem()
    {
        UseConsumableItem();
    }

    protected abstract void UseConsumableItem();
}