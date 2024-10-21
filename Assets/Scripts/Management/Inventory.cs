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
            item.UseItem();
        }
    }
    
}