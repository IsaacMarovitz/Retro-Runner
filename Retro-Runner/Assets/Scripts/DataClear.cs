using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataClear : MonoBehaviour {

    public void Clear() {

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.positionx = 0f;
        data.positiony = 30f;
        data.positionz = 0f;
        data.distance = 0f;
        binaryFormatter.Serialize(file, data);
        file.Close();

        Debug.Log("Data Cleared");

    }
}