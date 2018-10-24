using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    CollectableObject collectableObject;
    public Image icon;
    public Button removeButton;

    public void AddObject (CollectableObject collectable) {
        collectableObject = collectable;

        icon.sprite = collectableObject.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot () {
        collectableObject = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton() {
        Inventory.instance.Remove(collectableObject);
    }

    public void UseObject () {
        if (collectableObject != null) {
            // collectableObject.Use();
        }
    }
}
