using UnityEngine;
using System.Collections.Generic;

public class PositionLoader : MonoBehaviour {

    // public DevInfoMenu devInfoMenu;
    public float playerHealth;
    public List<CollectableObject> collectableObjects;
    public Inventory inventory;
    public PlayerDamage playerDamage;

    void Start() {
        // gameObject.transform.position = GameControl.LoadPosition();
    }

    void OnDisable() {
        collectableObjects = inventory.inventory;
        playerHealth = playerDamage.health;
        GameControl.Save(gameObject.transform, /*devInfoMenu.distance*/ 0, playerHealth, collectableObjects);
    }
}
