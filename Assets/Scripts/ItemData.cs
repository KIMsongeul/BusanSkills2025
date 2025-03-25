using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public enum ItemType
    {
        treasure,
        item
    }
    public enum ItemEffectType
    {
        hp,
        O2,
        treasure,
        speed1,
        speed2,
        hide
    }

    public string itemName;
    public ItemType type;
    public int itemWeight;
    public Sprite itemIcon;
    public ItemEffectType effectType;
}
