using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Slider score;

    void Update() {
        score.value = player.position.z;
    }
}
