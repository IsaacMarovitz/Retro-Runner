using UnityEngine;

public class Collision : MonoBehaviour {

    public Movement movement;
    public Vector3 lastVelocity;
    public float acceleration;
    public float force;
    public Rigidbody player;
    public bool hasCollided = false;

    void OnCollisionEnter(UnityEngine.Collision collision) {
        if (collision.gameObject.tag == "Obstacle") {
            movement.enabled = false;
            FindObjectOfType<Manager>().EndGame();
        }
        if (collision.gameObject.tag == "End") {
            movement.enabled = false;
            FindObjectOfType<Manager>().CompleteCheck();
        }
    }

    void Update() {
        acceleration = (player.velocity.z - lastVelocity.z) / Time.fixedDeltaTime;
        force = player.mass * acceleration;

        lastVelocity = player.velocity;
        if (hasCollided) {
            if (force < -200) {
                movement.enabled = false;
                FindObjectOfType<Manager>().EndGame();
            }
        }
    }
}
