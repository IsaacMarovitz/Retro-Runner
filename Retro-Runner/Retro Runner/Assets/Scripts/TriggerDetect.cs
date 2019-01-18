using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetect : MonoBehaviour {

    public Spawner spawner;

    void Start() {
        spawner = GameObject.Find("SceneManager").GetComponent<Spawner>();
    }

    // When the player is detected, spawn new ground
    void OnTriggerEnter(Collider collision) {
        Debug.Log(this.name);
        spawner.Spawn();
    }
}
