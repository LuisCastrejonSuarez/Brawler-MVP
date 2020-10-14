using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Inicio Singleton Pattern
    private static GameState instance;
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


}
