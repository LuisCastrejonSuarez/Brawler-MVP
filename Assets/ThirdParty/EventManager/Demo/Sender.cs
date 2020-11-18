using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigMonster.EventManager;
public class Sender : MonoBehaviour
{
    public static string EVENT = "EVENT1";
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SendMessage();
        }
    }
    public void SendMessage()
    {
        EventManager.TriggerEvent(EVENT, (object)"hello", this.gameObject);
    }
}
