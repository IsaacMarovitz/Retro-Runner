using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused;
    public GameObject pauseMenu;
    public GameObject loadingScreeen;
    public GameObject MainButtons;
    public GameObject OptionsButtons;
    //public GameObject DevInfo;
    public Slider slider;

    void Start() {
        Resume();
        isPaused = false;
    }

    void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (isPaused) {

                Resume();

            } else {

                Pause();
                MainButtons.SetActive(true);
                OptionsButtons.SetActive(false);
                //DevInfo.SetActive(false);

            }

        }

	}

    public void Resume() {

        //DevInfo.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    public void Pause() {

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }

    public void Quit() {
        Application.Quit();
    }

    public void PlayGame(string SceneName) {

        StartCoroutine(LoadAsynchronously(SceneName));

    }

    IEnumerator LoadAsynchronously(string SceneName) {

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        loadingScreeen.SetActive(true);

        while (!operation.isDone) {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;

        }
    }
}
