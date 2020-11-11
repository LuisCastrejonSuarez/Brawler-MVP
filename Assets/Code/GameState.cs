using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Game
{
    public int level;
    public float timeElapsed;
    public string playerName;
}

public class GameState : MonoBehaviour
{
    // Inicio Singleton Pattern
    private static GameState instance;

    // Save
    public Game saveData;

    public static GameState Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject();
                go.name = typeof(GameState).Name;
                instance = go.AddComponent<GameState>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        // asigna al nulo
        if (instance == null)
        {
            instance = this as GameState;
            DontDestroyOnLoad(gameObject);
        }
        // destruye al repetido
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StreamReader reader;
        try
        {
            reader = new StreamReader(Application.streamingAssetsPath + "/SaveData.data");
            while (reader.EndOfStream == false)
            {
                string line = reader.ReadLine();
                instance.saveData = JsonUtility.FromJson<Game>(line);
                Debug.Log(line);
                Debug.Log("Level: " + instance.saveData.level);
            }
        }catch(System.Exception e)
        {
            Save();
        }
    }

    public static void Save()
    {
        StreamWriter writer;

        instance.saveData.timeElapsed += Time.realtimeSinceStartup;

        string json = JsonUtility.ToJson(instance.saveData);

        writer = new StreamWriter(Application.streamingAssetsPath+"/SaveData.data");
        writer.Write(json);
        writer.Close();
    }
}
