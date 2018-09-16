using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

    public GameObject loadingScreeen;
    public Slider slider;

    public void PlayGame(string SceneName) {

        StartCoroutine(LoadAsynchronously(SceneName));

    }

    IEnumerator LoadAsynchronously (string SceneName) {

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        loadingScreeen.SetActive(true);

        while (!operation.isDone) {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;

        }
    }
}
