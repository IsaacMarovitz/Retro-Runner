using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    public float distance;

	void Awake () {
        if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if (control != this) {
            Destroy(gameObject);
        }
    }


    public static void Save (Transform playerPosition, float distance) {

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.positionx = playerPosition.position.x;
        data.positiony = playerPosition.position.y;
        data.positionz = playerPosition.position.z;
        data.distance += distance;
        binaryFormatter.Serialize(file, data);
        file.Close();

    }

    public static Vector3 LoadPosition () {

        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)binaryFormatter.Deserialize(file);
            file.Close();

            Vector3 position = new Vector3(data.positionx, data.positiony, data.positionz);

            return position;
        } else {
            return Vector3.zero;
        }

    }

    public float LoadDistance () {

        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)binaryFormatter.Deserialize(file);
            file.Close();

            distance = data.distance;

            return distance;
        } else {
            return 0f;
        }

    }
}

[Serializable]
public class PlayerData {
    public float positionx;
    public float positiony;
    public float positionz;
    public float distance;
}