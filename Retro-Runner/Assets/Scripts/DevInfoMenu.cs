using UnityEngine;
using UnityEngine.UI;

public class DevInfoMenu : MonoBehaviour {

    public Text xAxis;
    public Text yAxis;
    public Text zAxis;
    public Text Distance;
    public Text Speed;
    public Rigidbody rigid;
    public float rigidX;
    public float rigidY;
    public float rigidZ;
    public float distance;
    public float speed;
    public float roundRigidX;
    public float roundRigidY;
    public float roundRigidZ;
    public float roundDistance;
    public float roundSpeed;
    public Vector2 lastPosition;
    public Vector2 position;
    public Transform playerTransform;

    void Start() {
        lastPosition = new Vector2(rigidX, rigidZ);
    }

    void FixedUpdate() {
        position = new Vector2(rigidX, rigidZ);
        distance += Vector2.Distance(position, lastPosition);
        lastPosition = position;
    }

    void Update () {
        rigidX = playerTransform.position.x;
        rigidY = playerTransform.position.y;
        rigidZ = playerTransform.position.z;
        speed = rigid.velocity.magnitude;

        roundRigidX = Mathf.Round(rigidX * 10.0f) * 0.1f;
        roundRigidY = Mathf.Round(rigidY * 10.0f) * 0.1f;
        roundRigidZ = Mathf.Round(rigidZ * 10.0f) * 0.1f;
        roundDistance = Mathf.Round(distance * 10.0f) * 0.1f;
        roundSpeed = Mathf.Round(speed * 10.0f) * 0.1f;

        xAxis.text = "X: " + roundRigidX;
        yAxis.text = "Y: " + roundRigidY;
        zAxis.text = "Z: " + roundRigidZ;
        Distance.text = "Distance: " + roundDistance;
        Speed.text = "Speed: " + roundSpeed;

    }
}
