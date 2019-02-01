using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public Rigidbody rb;
    public int maxSpeed;
    public float forwardSpeed;
    public float acceleraiton;

    // Gets the ground's rigidbody and sets their inital speed
    void Start() {
        rb = GetComponent<Rigidbody> ();
        rb.velocity = transform.forward * maxSpeed;
    }

    // Increase their speed and set their velocity
    void Update() {
         forwardSpeed += Time.deltaTime * acceleraiton;
        if (forwardSpeed > maxSpeed) {
            forwardSpeed = maxSpeed;
        }
        rb.velocity = transform.forward * forwardSpeed;
    }
}
