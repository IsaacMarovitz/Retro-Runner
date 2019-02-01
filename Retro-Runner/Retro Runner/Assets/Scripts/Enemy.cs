using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Enemy Behaviour")]
    public GameObject player;
    public int health = 100;
    public RaycastHit hit;
    public Ray ray;
    public int shootSpeed;
    [Header("Enemy Movement")]
    public float xRangeMax;
    public float xRangeMin;
    public float yRangeMax;
    public float yRangeMin;
    public Vector3 enemyPosition;
    public int speed;
    public float xOffset;
    public float yOffset;
    public float zOffset = -3;

    void Start () {
        player = GameObject.Find("Player");
        ray = new Ray(transform.position, transform.forward);
        StartCoroutine(ShootInterval());
        Move();
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.transform.name == "Enemy(Clone") {
            Move();
        }
    }

    void Update () {
        enemyPosition = new Vector3(transform.position.x, transform.position.y, zOffset + player.transform.position.z);
        transform.position = enemyPosition;
        transform.LookAt(player.transform, Vector3.up);
    }

    public void Damage (int damage) {
        health -= damage;
        if (health <= 0) {
            Debug.Log("Enemy Destroyed");
            GameObject.Destroy(gameObject);
        }
    }

    public void Shoot () {
        if (Physics.Raycast(ray, out hit)) {
            Debug.DrawRay(transform.position, transform.forward, Color.black, 100f);
            Debug.Log(hit.transform.name);
            Player player = hit.transform.GetComponent<Player>();
            if (player != null) {
                player.Damage(10);
            }
        }
    }

    public void Move () {
        xOffset = Random.Range(xRangeMin, xRangeMax) + player.transform.position.x;
        yOffset = Random.Range(yRangeMin, yRangeMax) + player.transform.position.y;
        enemyPosition = new Vector3(Mathf.Lerp(transform.position.x, xOffset, speed * Time.deltaTime), Mathf.Lerp(transform.position.y, yOffset, speed * Time.deltaTime), transform.position.z);
        transform.position = enemyPosition;
    }

    IEnumerator ShootInterval () {
        Shoot();
        yield return new WaitForSeconds(shootSpeed);
    }
}
