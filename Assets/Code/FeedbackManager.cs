using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    // Inicio Singleton Pattern
    private static FeedbackManager instance;
    public static FeedbackManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject();
                go.name = typeof(FeedbackManager).Name;
                instance = go.AddComponent<FeedbackManager>();
            }
            return instance;
        }
    }

    //Variables FeedbackManager
    public CinemachineVirtualCamera vcam;
    public NoiseSettings noise;
    public GameObject dramaticLight;

    // Funcion Singleton
    private void Awake()
    {
        // asigna al nulo
        if (instance == null)
        {
            instance = this as FeedbackManager;
            DontDestroyOnLoad(gameObject);
        }
        // destruye al repetido
        else
        {
            Destroy(gameObject);
        }
    }

    //Fin Singleton

    public static void PlayFeedback(Feedback feed)
    {
        if (feed.audio != AudioManager.AUDIOS.NONE)
            AudioManager.PlaySound(feed.audio);
        if (feed.shake)
            instance.Shake();
        if (feed.drama)
            instance.DramaticLight();
    }

    private void Shake()
    {
        StartCoroutine(iShake());
    }
    private IEnumerator iShake()
    {
        vcam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = noise;
        yield return new WaitForSeconds(0.5f);
        vcam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = null;
        yield return null;
    }
    private void DramaticLight()
    {
        StartCoroutine(iDrama());
    }
    private IEnumerator iDrama()
    {
        dramaticLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        dramaticLight.SetActive(false);
        yield return null;
    }
}
