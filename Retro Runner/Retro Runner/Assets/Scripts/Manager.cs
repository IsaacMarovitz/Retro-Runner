using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public ColorToPrefab[] colorMappings;
    public Transform obstacleParent;
    public List<LevelObjects> levels;
    public float timeScale;
    public GameObject gameOver;
    public GameObject finishGame;
    public GameObject gameFinished;
    public GameObject player;
    public GameObject startUI;
    public float waitTime;
    public bool ended = false;
    public bool finished = false;
    public bool completed = false;
    public static bool hasStarted;
    public static int levelIndex;

    void Start() {
        obstacleParent = GameObject.Find("Obstacles").GetComponent<Transform>();
        player = GameObject.Find("Player");
        GenerateLevel();
        if (!hasStarted) {
            startUI.SetActive(true);
            player.GetComponent<Movement>().enabled = false;
            hasStarted = true;
        } else {
            startUI.SetActive(false);
            player.GetComponent<Movement>().enabled = true;
        }
    }

    void GenerateLevel() {
        Texture2D map = levels[levelIndex].map;
        for (int z = 0; z < map.width; z++) {
            for (int x = 0; x < map.height; x++) {
               GenerateTile(z, x, map); 
            }
        }
    }
    void GenerateTile(int z, int x, Texture2D map) {
        Color pixelColor = map.GetPixel(z, x);
        if (pixelColor.a == 0) {
            return;
        }
        foreach (ColorToPrefab colorMapping in colorMappings) {
            if (colorMapping.color.Equals(pixelColor)) {
                Vector3 position = new Vector3(x - 7.5f, 1, z);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, obstacleParent);
            }
        }
    }

    public void CompleteCheck() {
        if (levels.Count - 1 == levelIndex) {
            CompletedGame();
        } else {
            FinishLevel();
        }
    }

    public void EndGame() {
        Debug.Log("Game Over");
        Time.timeScale = timeScale;
        ended = true;
        StartCoroutine(Wait());
    }

    public void FinishLevel() {
        Debug.Log("Level Completed");
        Time.timeScale = timeScale;
        finished = true;
        StartCoroutine(Wait());
    }

    public void CompletedGame() {
        Debug.Log("Game Completed");
        Time.timeScale = timeScale;
        completed = true;
        StartCoroutine(Wait());
    }

    public void EndGameUI() {
        Time.timeScale = 1f;
        gameOver.SetActive(true);
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;
    }

    public void FinishLevelUI() {
        Time.timeScale = 1f;
        finishGame.SetActive(true);
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;
    }

    public void GameCompletedUI() {
        Time.timeScale = 1f;
        gameFinished.SetActive(true);
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;
    }
    
    public IEnumerator Wait() {
        yield return new WaitForSeconds(waitTime);
        if (ended) {
            EndGameUI();
        } else if (finished) {
            FinishLevelUI();
        } else if (completed) {
            GameCompletedUI();
        }
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        levelIndex++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
