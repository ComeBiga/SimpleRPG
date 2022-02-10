using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    public int healthGain;

    public override void Use()
    {
        base.Use();

        PlayerManager.instance.player.GetComponent<BaseStats>().Heal(healthGain);
        Inventory.instance.RemoveItem(this);
    }
}
