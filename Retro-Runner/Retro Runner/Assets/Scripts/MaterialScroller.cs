using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour {

    public GameObject planeObject;
    private Renderer planeRenderer;
    float scrollSpeed = 0.5f;

    // Start is called before the first frame update
    void Start() {
        planeObject = this.gameObject;
        planeRenderer = planeObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 textureOffset = new Vector2(0, Time.time*scrollSpeed);
        planeRenderer.material.mainTextureOffset = textureOffset;
    }
}
