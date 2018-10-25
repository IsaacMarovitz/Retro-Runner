using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    public float distance;
    //public CollectableObject[] inventory;

	void Awake () {
        if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if (control != this) {
            Destroy(gameObject);
        }
    }


    public static void Save (Transform playerPosition, float distance, float playerHealth, List<CollectableObject> inventory) {

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.positionx = playerPosition.position.x;
        data.positiony = playerPosition.position.y;
        data.positionz = playerPosition.position.z;
        data.playerHealth = playerHealth;
        data.inventory = inventory;
        data.distance += distance;
        binaryFormatter.Serialize(file, data);
        file.Close();

    }

    public static PlayerData Load () {

        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            Debug.Log(Application.persistentDataPath);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)binaryFormatter.Deserialize(file);
            file.Close();

            return data;
        } else {
            return null;
        }

    }

}

[Serializable]
public class PlayerData {
    public float positionx;
    public float positiony;
    public float positionz;
    public float distance;
    public List<CollectableObject> inventory;
    public float playerHealth;
}