using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour {

    public List<string> inventoryItems;
    public Collider[] colliders;
    public float radius;
    public TMP_Text collactableText;

    void Start() {

    }

    void Update () {
        colliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].tag == "Collectable") {
                collactableText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E)) {
                    inventoryItems.Add(colliders[i].gameObject.name);
                    Destroy(colliders[i].gameObject);
                }
            } else {
                collactableText.enabled = false;
            }
        }
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
