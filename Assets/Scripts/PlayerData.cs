using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PlayerData : MonoBehaviour
{ 
    private string path;

    void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "saved-files", "data.json");

        if (!File.Exists(path))
        {
            SerializeData(new PlayerJsonData(0));
        }

        PlayerJsonData data = DeserializeData();
        Debug.Log(data);
    }

    public void SerializeData(PlayerJsonData data)
    {
        /**
         * Serializes the JSON data given in the parameter.
         * 
         * TODO: Overload method with a parameter that accepts and handles
         * an array of JsonData objects.
         */
        string jsonDataString = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, jsonDataString);

        Debug.Log(jsonDataString);
    }

    public PlayerJsonData DeserializeData()
    {
        /**
         * Deserializes the given data, and returns 
         * the given JSON data.
         */
        PlayerJsonData data = JsonUtility.FromJson<PlayerJsonData>(File.ReadAllText(path));
        return data;
    }
}

/**
 * Data structure to manipulate JSON data within the
 * game save.
 */

[Serializable]
public class PlayerJsonData
{
    public int HiScore { get => hiScore; set => hiScore = value; }
    public int hiScore;

    public PlayerJsonData(int hiScore)
    {
        this.hiScore = hiScore;
    }

    public PlayerJsonData()
    {
        this.hiScore = 0;
    }
}