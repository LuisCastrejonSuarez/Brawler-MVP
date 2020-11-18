using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigMonster.EventManager;
using System;
using UnityEngine.UI;

public class Receiver : MonoBehaviour
{
    public Text txtMessages;
    void Start()
    {
        EventManager.StartListening(Sender.EVENT, Listener);
    }

    private void Listener(object data, GameObject sender)
    {
        Debug.Log(Sender.EVENT+" sent: " +(string)data);
        txtMessages.text += Sender.EVENT + " sent: " + (string)data + "\n";
    }
    
}
