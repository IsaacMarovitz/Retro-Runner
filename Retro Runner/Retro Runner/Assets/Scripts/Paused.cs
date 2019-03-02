using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour {

    public GameObject settings;
    public GameObject pause;

    public void Settings() {
        settings.SetActive(true);
        pause.SetActive(false);
    }

    public void Continue() {
        Time.timeScale = 1f;
        pause.SetActive(false);
    }
}
