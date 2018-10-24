using UnityEngine;

public class ObjectCollection : MonoBehaviour {

    public GameObject player;
    public InstantiateObjectInfo[] ObjectInfo;
    GameObject Instantiated;
    ObjectData InstantiatedData;

    void Start () {
        for (int i = 0; i < ObjectInfo.Length; i++) {
            // Instantiate the collectable objects with the correct transform, name, objectData, and tag
            Instantiated = Instantiate(ObjectInfo[i].objectPrefab, ObjectInfo[i].objectTransform, ObjectInfo[i].objectRotation);
            Instantiated.transform.parent = ObjectInfo[i].collectableParent.transform;
            Instantiated.name = ObjectInfo[i].name;
            InstantiatedData = Instantiated.GetComponent<ObjectData>();
            InstantiatedData.name = ObjectInfo[i].name;
            Instantiated.tag = "Collectable";
        }
    }
}

[System.Serializable]
public struct InstantiateObjectInfo {
    // Struct to make a custom editor array to make instantiating objects easier
    public string name;
    public GameObject objectPrefab;
    public Vector3 objectTransform;
    public Quaternion objectRotation;
    public GameObject collectableParent;
}
