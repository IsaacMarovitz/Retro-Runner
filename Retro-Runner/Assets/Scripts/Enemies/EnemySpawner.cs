using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnRate;
    public float spawnTime;
    public InstantiateObjectInfo enemy;
    float spawnRateChance;
    float finalSpawnRateChance;
    GameObject Instantiated;

    void Start () {
        spawnRateChance = spawnRate;
        StartCoroutine(SpawnEnemy(spawnRate, spawnTime, spawnRateChance, finalSpawnRateChance));
	}

    public void SpawnEnemies() {
        Debug.Log("Spawning Enemies");
        Instantiated = Instantiate(enemy.objectPrefab, enemy.objectTransform, enemy.objectRotation);
        Instantiated.transform.parent = enemy.collectableParent.transform;
        Instantiated.name = enemy.name;
        spawnRateChance = spawnRate;
    }

    IEnumerator SpawnEnemy (float spawnRate, float spawnTime, float spawnRateChance, float finalSpawnRateChance) {
        Debug.Log("Checking if Spawning Enemies");
        finalSpawnRateChance = spawnRateChance + Random.Range(0f, 5f);
        Debug.Log(finalSpawnRateChance);
        if (finalSpawnRateChance >= 5f) {
            SpawnEnemies();
        } else {
            spawnRateChance += 0.1f;
        }
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnEnemy(spawnRate, spawnTime, spawnRateChance, finalSpawnRateChance));
    }
}
