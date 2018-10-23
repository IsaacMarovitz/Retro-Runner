using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

    public Transform playerTransform;
    Vector3 OutOfBoundsVector3;
    public bool isStarted = true;

    void OnEnable() {
        if (isStarted == true) {
            playerTransform.position = new Vector3(0f, 30f, 0f);
            isStarted = false;
        }
    }

    void Update () {
        if (playerTransform.position.y < -5f) {
            OutOfBoundsVector3 = new Vector3(playerTransform.position.x, 30f, playerTransform.position.z);
            playerTransform.position = OutOfBoundsVector3;
        }
	}
}
