using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name = "new Item";
    public Sprite icon;

    public virtual void Use()
    {

    }

    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveItem(this);
    }
}
