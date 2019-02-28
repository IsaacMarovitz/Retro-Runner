using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    public Transform player;
    public TMP_Text score;

    void Update() {
        score.text = player.position.z.ToString("0");
    }
}
