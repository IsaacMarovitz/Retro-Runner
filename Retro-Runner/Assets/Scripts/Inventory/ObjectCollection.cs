using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollection : MonoBehaviour {

    public GameObject player;
    public InstantiateObjectInfo[] ObjectInfo;
    GameObject Instantiated;

    void Start () {
        for (int i = 0; i < ObjectInfo.Length; i++) {
            Instantiated = Instantiate(ObjectInfo[i].objectPrefab, ObjectInfo[i].objectTransform, ObjectInfo[i].objectRotation);
            Instantiated.transform.parent = ObjectInfo[i].collectableParent.transform;
            Instantiated.name = ObjectInfo[i].name;
            Instantiated.tag = "Collectable";
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
