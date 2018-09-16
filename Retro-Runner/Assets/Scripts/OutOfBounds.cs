using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

    Transform playerTransform;
    Vector3 OutOfBoundsVector3;

    void Start() {
        playerTransform = gameObject.transform;
    }

    void Update () {
        if (playerTransform.position.y < -5f) {
            OutOfBoundsVector3 = new Vector3(playerTransform.position.x, 30f, playerTransform.position.z);
            playerTransform.position = OutOfBoundsVector3;
        }
	}
}
