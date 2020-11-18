using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
namespace BigMonster.EventManager
{
    public class EventManager : MonoBehaviour
    {

        private Dictionary<string, ObjectEvent> eventDictionary;

        private static EventManager eventManager;

        public static EventManager instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                    if (!eventManager)
                    {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    }
                    else
                    {
                        eventManager.Init();
                    }
                }

                return eventManager;
            }
        }

        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, ObjectEvent>();
            }
        }

        public static void StartListening(string eventName, UnityAction<object, GameObject> listener)
        {
            ObjectEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new ObjectEvent();
                thisEvent.AddListener(listener);
                instance.eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, UnityAction<object, GameObject> listener)
        {
            if (eventManager == null) return;
            ObjectEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void TriggerEvent(string eventName, object data = null, GameObject trigger = null) //adds a new event in the dictionary
        {
            ObjectEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke(data, trigger);
            }
        }
    }
}