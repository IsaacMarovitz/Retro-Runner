using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuLoader : MonoBehaviour {

    public GameObject sliderObject;
    public GameObject playText;
    public Slider slider;
    public TMP_Text progressText;

    public void LoadGame(string sceneName) {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously (string sceneName) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        playText.SetActive(false);
        sliderObject.SetActive(true);
        while (!operation.isDone) {
            float progress = (operation.progress + 0.1f) * 100;
            slider.value = progress;
            Debug.Log(progress);
            progressText.text = progress + "%";
            yield return null;
        }
    }

}
