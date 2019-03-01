using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour {

    public static DontDestroyScript instance;
    public AudioSource music;

    public void Start() {
        if (instance != null) {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        if (music.isPlaying) 
            return;
        music.Play();
    }
}
