using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Vector3 newPosition;
    public int health = 100;
    public float newPositionX;
    public int sideSpeed;

    void Start() {
        newPositionX = transform.position.x;
    }

    // Checks for keys causing the player to go left or right, finally lerping their transfrom value
    void Update() {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (!(newPositionX >= 40)) {
                newPositionX = newPositionX += 10;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if (!(newPositionX <= -40)) {
                newPositionX = newPositionX -= 10;
            }
        }
        newPosition = new Vector3(Mathf.Lerp(transform.position.x, newPositionX, sideSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        transform.position = newPosition;
    }

    public void Damage (int damage) {
        health -= damage;
        if (health <= 0) {
            Debug.Log("Player Destroyed");
        }
    }
}
