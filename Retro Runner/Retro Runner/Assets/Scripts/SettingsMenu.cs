using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour {

    public Resolution[] resolutionSettings;
    public int resolutionIndex;
    public AudioMixer audioMixer;
    public GameObject start;
    public GameObject paused;
    public GameObject settings;
    public TMP_Text quality;
    public TMP_Text resolution;
    public Slider musicVolume;
    public Slider sfxVolume;
    public Toggle windowedToggle;

    void Start() {
        resolutionSettings = Screen.resolutions;
        for (int i = 0; i < resolutionSettings.Length; i++) {
            if (resolutionSettings[i].width == Screen.currentResolution.width) {
                if (resolutionSettings[i].height == Screen.currentResolution.height) {
                    if (resolutionSettings[i].refreshRate == Screen.currentResolution.refreshRate) {
                        resolutionIndex = i -1;
                        resolution.text = resolutionSettings[i].width + " x " + resolutionSettings[i].height;
                    }
                }
            }
        }
        quality.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
        resolution.text = Screen.width + " x " + Screen.height;
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
        QualitySettings.DecreaseLevel();
        quality.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
    }

    public void QualityRight() {
        QualitySettings.IncreaseLevel();
        quality.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
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

    public void MusicVolume() {
        audioMixer.SetFloat("MusicVolume", musicVolume.value);
    }

    public void SFXVolume() {
        audioMixer.SetFloat("SFXVolume", sfxVolume.value);
    }
}
