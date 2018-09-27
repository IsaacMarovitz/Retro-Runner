﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PostProcessing;

public class OptionsMenu : MonoBehaviour {

	public AudioMixer audiomixer;
	public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    Resolution[] resolutions;


	void Start () {
    
        resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();
		List<string> options = new List<string>();
		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {

			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width &&
					resolutions[i].height == Screen.currentResolution.height) {

				currentResolutionIndex = i;

			}

		}
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();

        if (Screen.fullScreen == true) {

            fullscreenToggle.isOn = true;

        } else {

            fullscreenToggle.isOn = false;

        }

	}

    public void SetResolution () {

        Resolution resolution = resolutions[resolutionDropdown.value];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

	}

	public void SetVolume (float volume) {

		audiomixer.SetFloat("volume", volume);

	}

    public void SetVolumeMusic(float volume) {

        audiomixer.SetFloat("volumeMusic", volume);

    }

    public void SetVolumeFX(float volume) {

        audiomixer.SetFloat("volumeFX", volume);

    }

    public void SetQuality (TMP_Dropdown graphicsDropdown) {

        QualitySettings.SetQualityLevel(graphicsDropdown.value);

	}

	public void SetFullscreen (bool isFullscreen) {

		Screen.fullScreen = isFullscreen;

	}
}
