using UnityEngine;

public enum ItemName
{
    HealPack = 0,
    PowerPack,
    SpeedPack,
    Count
}

public class ItemDropper : Dropper
{
    protected override void Drop()
    {
        int rand = Random.Range(0, (int)ItemName.Count);
        string itemName;
        
        switch (rand)
        {
            case 0:
                itemName = ItemName.HealPack.ToString();
                break;
            case 1:
                itemName = ItemName.PowerPack.ToString();
                break;
            case 2:
                itemName = ItemName.SpeedPack.ToString();
                break;
            default:
                itemName = ItemName.HealPack.ToString();
                break;
        }


       GameObject item =  ObjectPool.instance.SpawnFromPool(itemName);
       item.transform.position = this.transform.position;
       item.GetComponent<Item>().OnEnableItem();
    }
}