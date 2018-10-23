using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollection : MonoBehaviour {

    public TMP_Text score;
    public int scoreInt = 0;
    public GameObject player;
    public InstantiateObjectInfo[] ObjectInfo;
    GameObject Instantiated;

    void Start () {
        score.text = "Score: " + scoreInt.ToString();
        for (int i = 0; i < ObjectInfo.Length; i++) {
            Instantiated = Instantiate(ObjectInfo[i].objectPrefab, ObjectInfo[i].objectTransform, ObjectInfo[i].objectRotation);
            Instantiated.transform.parent = ObjectInfo[i].collectableParent.transform;
            Instantiated.name = ObjectInfo[i].name;
            Instantiated.tag = "Collectable";
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Collectable") {
            scoreInt++;
            score.text = "Score: " + scoreInt.ToString();
            Destroy(collision.gameObject);
        }
    }
}

[System.Serializable]
public struct InstantiateObjectInfo {
    public string name;
    public GameObject objectPrefab;
    public Vector3 objectTransform;
    public Quaternion objectRotation;
    public GameObject collectableParent;
}
