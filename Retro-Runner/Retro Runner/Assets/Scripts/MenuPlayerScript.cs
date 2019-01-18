using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerScript : MonoBehaviour {

    public Vector3 newPosition;
    public Rigidbody rb;
    public int maxSpeed;
    public float forwardSpeed;
    public float acceleraiton;

    // Gets the player's rigidbody and sets their inital speed
    void Start() {
        rb = GetComponent<Rigidbody> ();
        rb.velocity = transform.forward * forwardSpeed;
    }

    // Checks for keys causing the player to go left or right, and increase their speed, finally lerping their transfrom value and setting their velocity
    void Update() {
        forwardSpeed += Time.deltaTime * acceleraiton;
        if (forwardSpeed > maxSpeed) {
            forwardSpeed = maxSpeed;
        }
        rb.velocity = transform.forward * forwardSpeed;
        newPosition = new Vector3(0, 0.8f, transform.position.z);
        transform.position = newPosition;
    }
}
