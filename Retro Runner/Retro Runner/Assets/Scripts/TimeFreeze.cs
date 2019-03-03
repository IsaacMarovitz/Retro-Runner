using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreeze : MonoBehaviour {
    public void TimeFreezer() {
        Debug.Log("Freezing");
        Time.timeScale = 0f;
    }
}
