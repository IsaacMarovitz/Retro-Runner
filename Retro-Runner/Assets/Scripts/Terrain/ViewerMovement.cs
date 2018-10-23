using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerMovement : MonoBehaviour {

    public float speed = 1.5f;
    public float spacing = 1.0f;
    public Vector3 position;

    void Start() {

        position = transform.position;

    }

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.W)) {
            
            position.z += spacing;

        } else if (Input.GetKeyDown(KeyCode.A)) {

            position.x -= spacing;

        } else if (Input.GetKeyDown(KeyCode.S)) {

            position.z -= spacing;

        } else if (Input.GetKeyDown(KeyCode.D)) {

            position.x += spacing;

        }

        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

    }
}
