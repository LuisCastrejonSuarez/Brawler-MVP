using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Inicio Singleton Pattern
    private static AudioManager instance;

    // Variables de Audio Manager
    public List<AudioClip> clips;
    public AudioSource asource;
    public enum AUDIOS
    {
        KILL = 0,
        PUNCH = 1,
        SPLASH = 2,
    };

    // Funciones Singleton
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject();
                go.name = typeof(AudioManager).Name;
                instance = go.AddComponent<AudioManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        // asigna al nulo
        if (instance == null)
        {
            instance = this as AudioManager;
            DontDestroyOnLoad(gameObject);
        }
        // destruye al repetido
        else
        {
            Destroy(gameObject);
        }

    }

    // Funciones de Audio Manager
    public static void PlaySound(AUDIOS index)
    {
        instance.asource.Stop();
        instance.asource.clip = instance.clips[(int)index];
        instance.asource.Play();
    }
}
