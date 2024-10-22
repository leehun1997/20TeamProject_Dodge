using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    private LayerMask itemLayerMask = 1 << 9;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if ((itemLayerMask & (1 << collision.gameObject.layer)) != 0)
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                Debug.Log("Item detected: " + item.itemName);
                // 스피드 또는 파워 아이템일 때 개수를 증가시킴
                if (item.itemName == ItemName.PowerPack || item.itemName == ItemName.SpeedPack)
                {
                    GameManager.Instance.AddItem(item.itemName);
                }

                item.UseItem();
            }
        }
    }
    
}