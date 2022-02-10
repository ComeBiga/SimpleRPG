using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance = null;

    public void Awake()
    {
        instance = this;
    }
    #endregion

    public System.Action onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public List<InventorySlot> slots;

    public bool AddItem(Item _item)
    {
        if(items.Count > space)
        {
            return false;
        }

        items.Add(_item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        return true;
    }

    public void RemoveItem(Item _item)
    {
        items.Remove(_item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
