using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public Vector3 enemyPosition;
    public int speed;
    public float xOffset;
    public float yOffset;
    public float zOffset = -3;
    public float lerpSpeed = 1f;

    void Start() {
        player = GameObject.Find("Player");
    }

    void Update() {
        enemyPosition = player.transform.position;
        enemyPosition.x = xOffset;
        enemyPosition.y = yOffset;
        enemyPosition.z = zOffset;
        transform.position = enemyPosition;
    }
}
