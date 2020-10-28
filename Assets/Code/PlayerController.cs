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
    public PlayerInput player;
    public Animator animator;

    public void OnMove(InputAction.CallbackContext callback)
    {
        input.move = callback.ReadValue<Vector2>();
        if(input.move.x!=0)
            transform.localScale = new Vector3((input.move.x < 0) ? -1 : 1, 1, 1);
    }
    public void OnPunch(InputAction.CallbackContext callback)
    {
        Debug.Log("punching");
        if(callback.phase== InputActionPhase.Started)
        input.punch = true;
    }
    private void OnEnable()
    {
        Debug.Log("Player " + player.playerIndex + " Joined!!");

        gameObject.transform.position = Vector3.zero;

        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = newColor;
        }
    }
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        player = GetComponent<PlayerInput>();
    }
    void Update()
    {
        Vector3 finalmovement = new Vector3(input.move.x, 0, input.move.y);
        controller.Move(finalmovement * Time.deltaTime * 5);
        /* animator update */
        animator.SetFloat("speed", finalmovement.magnitude);
        

        if (input.punch)
        {
            input.punch = false;
            animator.SetTrigger("punch");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Damage")
        {
            animator.SetTrigger("damage");
        }
    }
}
