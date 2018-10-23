using UnityEngine;

public class PositionLoader : MonoBehaviour {

    public DevInfoMenu devInfoMenu; 

    void Start() {
        gameObject.transform.position = GameControl.LoadPosition();
    }

    void OnDisable() {
        GameControl.Save(gameObject.transform, devInfoMenu.distance);
    }
}
