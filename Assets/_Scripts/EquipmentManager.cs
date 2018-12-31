using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	#region Singleton
	public static EquipmentManager instance { get; private set; }

	private void Awake(){
		if (instance != null) {
			Destroy (this);
		} else {
			instance = this;
		}
			
	}

	#endregion

	public Equipment[] currentEquipment;

	Inventory inventory;

	public delegate void OnEquipmentChanged (Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChangedCallback;


	void Start(){
		// string array of all types of equipment
		inventory = Inventory.instance;
		int numSlots = System.Enum.GetNames (typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numSlots];
	//	currentMeshes = new SkinnedMeshRenderer[numSlots];
	}

	public void Equip(Equipment newItem){
		int slotIndex = (int)newItem.equipSlot;
		Equipment oldItem = Unequip (slotIndex);

		currentEquipment [slotIndex] = newItem;
		onEquipmentChangedCallback.Invoke (newItem, oldItem);
		inventory.onItemChangedCallback.Invoke ();
//		SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer> (newItem.mesh);
	//	newMesh.transform.SetParent (targetMesh.transform);

		//newMesh.bones = targetMesh.bones;
	//	newMesh.rootBone = targetMesh.rootBone;
		//currentMeshes [slotIndex] = newMesh;
	}

	public void Equip(Equipment newItem, int inventorySlotIndex){
		int slotIndex = (int)newItem.equipSlot;
		Equipment oldItem = Unequip (slotIndex);

		currentEquipment [slotIndex] = newItem;
		onEquipmentChangedCallback.Invoke (newItem, oldItem);
		inventory.onItemChangedCallback.Invoke ();

	}

	public Equipment Unequip(int slotIndex){
		if (currentEquipment [slotIndex] != null) {

			Equipment oldItem = currentEquipment [slotIndex];
			inventory.Add (oldItem);

			currentEquipment [slotIndex] = null;
			Equipment noNewItem = null;
			onEquipmentChangedCallback (noNewItem, oldItem);
			inventory.onItemChangedCallback.Invoke ();
			return oldItem;
		}
		return null;
	}

	public Equipment Unequip(int slotIndex, int inventorySlotIndex){
		if (currentEquipment [slotIndex] != null) {

			Equipment oldItem = currentEquipment [slotIndex];
			inventory.items[inventorySlotIndex] = oldItem;

			currentEquipment [slotIndex] = null;

			Equipment noNewItem = null;
			onEquipmentChangedCallback (noNewItem, oldItem);
			inventory.onItemChangedCallback.Invoke ();
			return oldItem;
		}
		return null;
	}

	public void UnequipAll(){
		for (int i = 0; i < currentEquipment.Length; i++) {
			Unequip (i);
		}
	}

}