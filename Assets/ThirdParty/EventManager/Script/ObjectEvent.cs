using UnityEngine;
using System.Collections;
using UnityEngine.Events;
namespace BigMonster.EventManager
{
    [System.Serializable]
    public class ObjectEvent : UnityEvent<object, GameObject>
    {

    }
}