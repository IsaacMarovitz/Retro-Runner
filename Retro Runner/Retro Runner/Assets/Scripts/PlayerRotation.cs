using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    public Transform playerTransform;
    public float speed;

    void Update() {
        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, Quaternion.identity, speed * Time.deltaTime);
    }
}
