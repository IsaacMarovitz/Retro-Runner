using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public Vector3 newPosition;
    public Rigidbody rb;
    public int sideSpeed;
    public int maxSpeed;
    public int x;
    public float forwardSpeed;
    public float acceleraiton;
    public float newPositionX;

    // Gets the player's rigidbody and sets their inital speed
    void Start() {
        rb = GetComponent<Rigidbody> ();
        rb.velocity = transform.forward * forwardSpeed;
    }

    // Checks for keys causing the player to go left or right, and increase their speed, finally lerping their transfrom value and setting their velocity
    void Update() {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (!(x >= 40)) {
                newPositionX = newPositionX += 10;
                x = Mathf.RoundToInt(newPositionX);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if (!(x <= -40)) {
                newPositionX = newPositionX -= 10;
                x = Mathf.RoundToInt(newPositionX);
            }
        }
        forwardSpeed += Time.deltaTime * acceleraiton;
        if (forwardSpeed > maxSpeed) {
            forwardSpeed = maxSpeed;
        }
        rb.velocity = transform.forward * forwardSpeed;
        newPosition = new Vector3(Mathf.Lerp(transform.position.x, newPositionX, sideSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
