using UnityEngine;
using TMPro;

public class FramesPerSecond : MonoBehaviour {

    public TextMeshProUGUI fpsText;
    public float deltaTime = 0.0f;

    void Update() {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = fps.ToString();
    }

    void OnGUI() {
        float fps = 1.0f / deltaTime;
    }
}
