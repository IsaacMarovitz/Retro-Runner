using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;

    // Code for a singleton to save time lol
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one instace of Inventory!");
            return;
        }
        instance = this;
    }

    public List<ObjectData> inventory = new List<ObjectData>();

    // Add stuff to inventory
    public void Add (ObjectData objectData) {
        inventory.Add(objectData);
    }

    // Remove stuff from inventory
    public void Remove(ObjectData objectData) {
        inventory.Remove(objectData);
    }

}
