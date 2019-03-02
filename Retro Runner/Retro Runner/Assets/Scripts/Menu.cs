using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject player;
    public GameObject settings;
    public GameObject startMenu;
    public Animator animator;
    public static bool gameHasStarted;

    public void Start() {
        player.GetComponent<Movement>().enabled = false;
        gameHasStarted = false;
    }

    public void StartGame() {
        animator.Play("Start");
        gameHasStarted = true;
    }

    public void HideUI() {
        player.GetComponent<Movement>().enabled = true;
        startMenu.SetActive(false);
    }

    public void StartSettings() {
        startMenu.SetActive(false);
        settings.SetActive(true);
    }
}
