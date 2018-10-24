using UnityEngine;

public class InventoryUI : MonoBehaviour {

    Inventory inventory;
    public Transform slotParents;
    InventorySlot[] slots;
    public GameObject inventoryUI;

	void Start () {
        inventory = Inventory.instance;
        inventory.onIteamChangedCallback += UpdateUI;

        slots = slotParents.GetComponentsInChildren<InventorySlot>();
	}
	
	void Update () {
        if (Input.GetButtonDown("Inventory")) {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    void UpdateUI () {
        for (int i = 0; i < slots.Length; i++) {
            if (i < inventory.inventory.Count) {
                slots[i].AddObject(inventory.inventory[i]);
            } else {
                slots[i].ClearSlot();
            }
        }
    }


}
