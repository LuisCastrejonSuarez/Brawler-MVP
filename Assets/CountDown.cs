using BigMonster.EventManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text uiText;
    private void Awake()
    {
        uiText = GetComponent<Text>();
    }
    private void Start()
    {
        StartCoroutine(StartCountDown(3, 3));
    }
    IEnumerator StartCountDown(int count, int delay)
    {
        uiText.text = "";
        yield return new WaitForSeconds(delay);
        uiText.text = count.ToString();
        while (count>1)
        {
            yield return new WaitForSeconds(1f);
            --count;
            uiText.text = count.ToString();
        }
        yield return new WaitForSeconds(1f);
        uiText.text = "Go!";
        yield return new WaitForSeconds(1f);
        uiText.enabled = false;
        EventManager.TriggerEvent(GameState.GAME_START);
        yield return null;
    }
}
