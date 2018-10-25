using UnityEngine;
using TMPro;

public class PlayerDamage : MonoBehaviour {

    public float health = 200f;
    public TMP_Text healthText;
    public PauseMenu pauseMenu;

    public void Damage (float amount) {
        health -= amount;
        if (health <= 0f) {
            Debug.Log("You Died");
            pauseMenu.Pause();
        }
    }

    void Start() {
        // health = GameControl.LoadHealth();
    }

    void Update() {
        healthText.text = "Health: " + health;
    }
}
