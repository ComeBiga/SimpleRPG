using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item = null;

    private void Start()
    {
        if (item == null)
            Debug.LogError("Didn't set item in ItemPickup.");
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        if(Inventory.instance.AddItem(item))
            Destroy(this.gameObject);
    }
}
