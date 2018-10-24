﻿using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour {

    public Collider[] colliders;
    public float radius;
    public TMP_Text collactableText;
    public ObjectData objectData;
    public GameObject collectableObject;

    void Update () {
        // Make a bubble see whats in it. If it's collectable give the user the option to pick it up
        colliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].tag == "Collectable") {
                collectableObject = colliders[i].gameObject;
                collactableText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E)) {
                    objectData = collectableObject.GetComponent<ObjectData>();
                    Debug.Log(objectData.name);
                    bool inventoryAdded = Inventory.instance.Add(objectData.collectableObject);
                    if (inventoryAdded) {
                        Destroy(collectableObject);
                    }
                }
            } else {
                collactableText.enabled = false;
            }
        }
    }


    // Editor stuff to make debugging easier
    void OnDrawGizmosSelected () {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}