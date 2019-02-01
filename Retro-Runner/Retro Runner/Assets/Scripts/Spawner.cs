using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject ground;
    public GameObject enemy;
    public GameObject instantiatedGround;
    public Transform groundParent;
    public Transform enemyParent;
    public Vector3 groundPosition;
    public Vector3 enemyPosition;
    public List<GameObject> groundList;
    public int startDistance = 12;
    public float z;
    public float x = 9;

    // Spawns original ground
    public void Start() {
        SpawnStart();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }

    public void SpawnStart() {
        // Loops though for how far out the blocks go by how wide they are and instantiates them
        for (int i = 0; i < startDistance; i++) {
            groundPosition = new Vector3(-40, 0, z);
            for (int y = 0; y < x; y++) {
                instantiatedGround = Instantiate(ground, groundPosition, Quaternion.identity, groundParent);
                groundPosition.x += 10;
                groundList.Add(instantiatedGround);
            }
            z -= 10;
        }
    }
    public void Spawn() {
        // Instantiates the new ground ahead the of the player and removes the ground behind them
        groundPosition = new Vector3(-40, 0, z);
        for (int i = 0; i < x; i++) {
            instantiatedGround = Instantiate(ground, groundPosition, Quaternion.identity, groundParent);
            groundPosition.x += 10;
            groundList.Add(instantiatedGround);
        }
        z -= 10;
        for (int i = 8; i >= 0; i--) {
            Destroy(groundList[i]);
        }
        groundList.RemoveRange(0, 9);
    }

    public void SpawnEnemy() {
        Instantiate(enemy, enemyPosition, Quaternion.identity, enemyParent);
    }
}