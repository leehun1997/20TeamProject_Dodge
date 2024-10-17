using System;
using UnityEngine;

public enum ItemType
{
    Equipable, // 장비형 아이템
    Consumable // 사용하는 아이템 (예: 포션 등)
}

//Player만 사용 가능하도록 설계 
public abstract class Item : MonoBehaviour
{
    protected CharacterStatHandler playerStat;
    protected ItemType ItemType;

    protected virtual void Awake()
    {
        playerStat = GetComponent<CharacterStatHandler>();
    }

    protected abstract void UseItem();
    
}