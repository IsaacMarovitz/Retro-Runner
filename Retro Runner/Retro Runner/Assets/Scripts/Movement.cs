using UnityEngine;

public class Movement : MonoBehaviour {
    
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public bool moveLeft = false;
    public bool moveRight = false;

    void Update() {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            moveRight = true;
        } else {
            moveRight = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            moveLeft = true;
        } else {
            moveLeft = false;
        }
        if (!(transform.rotation == Quaternion.identity)) {
            transform.Rotate(Vector3.right * Time.deltaTime);
        }
    }

    void FixedUpdate() {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (moveRight) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (moveLeft) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < -1f) {
            FindObjectOfType<Manager>().EndGame();
        }
    }
}
