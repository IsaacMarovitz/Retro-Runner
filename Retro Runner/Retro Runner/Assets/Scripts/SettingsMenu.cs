using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour {

    public string[] qualitySettings;
    public int qualityIndex;
    public static Resolution[] resolutionSettings;
    public static int resolutionIndex;
    public List<string> resolutionSettingsInspector;
    public int resolutionIndexInspector;
    public AudioMixer audio;
    public GameObject start;
    public GameObject paused;
    public GameObject settings;
    public TMP_Text quality;
    public TMP_Text resolution;
    public Slider musicVolume;
    public Slider sfxVolume;
    public Toggle windowedToggle;

    void Start() {
        qualitySettings = QualitySettings.names;
        resolutionSettings = Screen.resolutions;
        qualityIndex = QualitySettings.GetQualityLevel();
        for (int i = 0; i < resolutionSettings.Length; i++) {
            if ((Screen.currentResolution.height == resolutionSettings[i].height) && (Screen.currentResolution.width == resolutionSettings[i].width) && (Screen.currentResolution.refreshRate == resolutionSettings[i].refreshRate)) {
                resolutionIndex = i;  
            }
        }
        quality.text = qualitySettings[qualityIndex];
        resolution.text = resolutionSettings[resolutionIndex].width + " x " + resolutionSettings[resolutionIndex].height;
        windowedToggle.isOn = Screen.fullScreen;
        for (int i = 0; i < resolutionSettings.Length; i++) {
            resolutionSettingsInspector.Add(resolutionSettings[i].ToString());
        }
        resolutionIndexInspector = resolutionIndex;
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
            resolutionIndexInspector = resolutionIndex;
            resolution.text = resolutionSettings[resolutionIndex].width + " x " + resolutionSettings[resolutionIndex].height;
            Screen.SetResolution(resolutionSettings[resolutionIndex].width, resolutionSettings[resolutionIndex].height, windowedToggle.isOn);
        }
    }

    public void ResolutionRight() {
        if (!(resolutionIndex >= resolutionSettings.Length - 1)) {
            resolutionIndex += 1;
            resolutionIndexInspector = resolutionIndex;
            resolution.text = resolutionSettings[resolutionIndex].width + " x " + resolutionSettings[resolutionIndex].height;
            Screen.SetResolution(resolutionSettings[resolutionIndex].width, resolutionSettings[resolutionIndex].height, windowedToggle.isOn);
        }
    }

    public void Fullscreen() {
        Screen.fullScreen = windowedToggle.isOn;
    }

    public void MusicVolume() {
        audio.SetFloat("MusicVolume", musicVolume.value);
    }

    public void SFXVolume() {
        audio.SetFloat("SFXVolume", sfxVolume.value);
    }
}
