using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentType type;
    public GameObject mesh;
    public int damageModifier;
    public int armorModifier;

    public override void Use()
    {
        base.Use();

        Debug.Log("Equip " + name);
        EquipmentManager.Instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentType { Head, Chest, Weapon }
