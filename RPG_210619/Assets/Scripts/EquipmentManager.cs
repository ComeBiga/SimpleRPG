using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : Singleton<EquipmentManager>
{
    [SerializeField]
    private Equipment[] currentEquipment;
    public GameObject[] targetMeshes = new GameObject[3];

    GameObject[] currentMeshes = new GameObject[3];

    public System.Action<Equipment> OnEquipmentChanged;

    Inventory inventory;

    public void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentType)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.type;

        currentEquipment[slotIndex] = newItem;

        if (OnEquipmentChanged != null)
            OnEquipmentChanged.Invoke(newItem);

        AttachEquipment(newItem);
    }

    public void AttachEquipment(Equipment newItem)
    {
        int slotIndex = (int)newItem.type;

        currentMeshes[slotIndex] = Instantiate(newItem.mesh, targetMeshes[slotIndex].transform);
    }
}
