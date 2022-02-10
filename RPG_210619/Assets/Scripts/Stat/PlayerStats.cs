using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : BaseStats
{
    protected override void Start()
    {
        base.Start();

        EquipmentManager.Instance.OnEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem)
    {
        if(newItem != null)
        {
            damage.AddModifier(newItem.damageModifier);
            armor.AddModifier(newItem.armorModifier);
        }
    }

    public override void Die()
    {
        base.Die();
    }
}
