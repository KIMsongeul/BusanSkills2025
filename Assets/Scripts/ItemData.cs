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

    public string itemName;
    public ItemType type;
    public int itemWeight;
    public Sprite itemIcon;
}
