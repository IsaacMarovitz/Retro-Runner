using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject player;
    public GameObject startMenu;
    public Animator animator;

    public void Start() {
        player.GetComponent<Movement>().enabled = false;
    }

    public void StartGame() {
        animator.Play("Start");
    }

    public void HideUI() {
        player.GetComponent<Movement>().enabled = true;
        startMenu.SetActive(false);
    }
}
