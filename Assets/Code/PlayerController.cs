using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public struct InputMapGame
{
    public Vector2 move;
    public bool punch;
}
public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public InputMapGame input;
    public void OnMove(InputAction.CallbackContext callback)
    {
        input.move = callback.ReadValue<Vector2>();
    }
    public void OnPunch(InputAction.CallbackContext callback)
    {
        input.punch = true;
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 finalmovement = new Vector3(input.move.x, 0, input.move.y);
        controller.Move(finalmovement * Time.deltaTime * 5);
        if (input.punch)
        {
            input.punch = false;
            Debug.Log("punch!");
        }
    }
}
