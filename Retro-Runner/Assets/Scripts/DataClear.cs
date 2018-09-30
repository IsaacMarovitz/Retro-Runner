using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class DataClear : MonoBehaviour {

    public TMP_Text clearData;

    public void Clear() {

        clearData.text = "";
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.positionx = 0f;
        data.positiony = 30f;
        data.positionz = 0f;
        data.distance = 0f;
        binaryFormatter.Serialize(file, data);
        file.Close();

        clearData.text = "Data Cleared";
        Debug.Log("Data Cleared");

    }
}