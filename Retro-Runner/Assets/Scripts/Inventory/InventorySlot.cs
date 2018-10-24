using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    CollectableObject collectableObject;
    public Image icon;

    public void AddObject (CollectableObject collectable) {
        collectableObject = collectable;

        icon.sprite = collectableObject.icon;
        icon.enabled = true;
    }

    public void ClearSlot () {
        collectableObject = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
