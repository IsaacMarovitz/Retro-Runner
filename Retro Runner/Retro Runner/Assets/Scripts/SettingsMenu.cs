using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour {

    public string[] qualitySettings;
    public Resolution[] resolutionSettings;
    public int qualityIndex;
    public int resolutionIndex;
    public AudioSource music;
    public GameObject start;
    public GameObject paused;
    public GameObject settings;
    public TMP_Text quality;
    public TMP_Text resolution;
    public Slider musicVolume;
    public Toggle windowedToggle;

    void Start() {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        qualitySettings = QualitySettings.names;
        resolutionSettings = Screen.resolutions;
        Screen.fullScreen = true;
        qualityIndex = QualitySettings.GetQualityLevel();
        for (int i = 0; i < resolutionSettings.Length; i++) {
            if (resolutionSettings[i].ToString() == Screen.currentResolution.ToString()) {
                resolutionIndex = i;
            }
        }
        quality.text = qualitySettings[qualityIndex];
        resolution.text = resolutionSettings[resolutionIndex].width + " x " + resolutionSettings[resolutionIndex].height;
        musicVolume.value = music.volume;
        windowedToggle.isOn = Screen.fullScreen;
    }

    public void Back() {
        if (Menu.gameHasStarted) {
            paused.SetActive(true);
            settings.SetActive(false);
        } else {
            start.SetActive(true);
            settings.SetActive(false);
        }
    }

    public void QualityLeft() {
        if (!(qualityIndex <= 0)) {
            qualityIndex -= 1;
            quality.text = qualitySettings[qualityIndex];
            QualitySettings.SetQualityLevel(qualityIndex);
        }
    }

    public void QualityRight() {
        if (!(qualityIndex >= qualitySettings.Length - 1)) {
            qualityIndex += 1;
            quality.text = qualitySettings[qualityIndex];
            QualitySettings.SetQualityLevel(qualityIndex);
        }
    }

    public void ResolutionLeft() {
        if (!(resolutionIndex <= 0)) {
            resolutionIndex -= 1;
            resolution.text = resolutionSettings[resolutionIndex].width + " x " + resolutionSettings[resolutionIndex].height;
            Screen.SetResolution(resolutionSettings[resolutionIndex].width, resolutionSettings[resolutionIndex].height, windowedToggle.isOn);
        }
    }

    public void ResolutionRight() {
        if (!(resolutionIndex >= resolutionSettings.Length - 1)) {
            resolutionIndex += 1;
            resolution.text = resolutionSettings[resolutionIndex].width + " x " + resolutionSettings[resolutionIndex].height;
            Screen.SetResolution(resolutionSettings[resolutionIndex].width, resolutionSettings[resolutionIndex].height, windowedToggle.isOn);
        }
    }

    public void Fullscreen() {
        Screen.fullScreen = windowedToggle.isOn;
    }

    public void Volume() {
        music.volume = musicVolume.value;
    }
}
