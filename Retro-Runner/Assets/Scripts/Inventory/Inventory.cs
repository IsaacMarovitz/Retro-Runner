using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;
    public int space = 20;
    public delegate void OnIteamChanged();
    public OnIteamChanged onIteamChangedCallback;

    // Code for a singleton to save time lol
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one instace of Inventory!");
            return;
        }
        instance = this;
    }

    public List<CollectableObject> inventory = new List<CollectableObject>();

    // Add stuff to inventory
    public bool Add (CollectableObject collectableObject) {
        if (inventory.Count >= space) {
            Debug.Log("Not enough space");
            return false;
        }
        inventory.Add(collectableObject);
        if (onIteamChangedCallback != null) {
            onIteamChangedCallback.Invoke();
        }
        return true;
    }

    // Remove stuff from inventory
    public void Remove(CollectableObject collectableObject) {
        inventory.Remove(collectableObject);
        if (onIteamChangedCallback != null) {
            onIteamChangedCallback.Invoke();
        }
    }

}
