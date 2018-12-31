﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;
    //public SkinnedMeshRenderer mesh;

    public int armorModifier;
    public int damageModifier;
    [Tooltip ("Formula for attack speed is 1 / mod attacks = time between attacks")]
    public int attackSpeedModifer;
    [Tooltip ("Multiply disired worldview distance by 10")]
    public int attackRangeModifier;

    public override void Use(int inventorySlotIndex){
        base.Use ();

        EquipmentManager.instance.Equip (this, inventorySlotIndex);
        RemoveFromInventory ();
    }

}

public enum EquipmentSlot{ head, ring, chest, weapon, legs, shield }