using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.01f;
    [SerializeField] float turnSpeed = 0.1f;

    PlayerInput playerInput;
    InputAction moveAction;

    void Awake() 
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();

        // transform.Rotate(0,0,turnSpeed);
        // transform.Translate(0,movementSpeed,0);
    }

    void MovePlayer()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        float acceleration = input.y * movementSpeed;
        float turning = -input.x * turnSpeed;

        transform.Translate(0, acceleration, 0);
        transform.Rotate(0, 0, turning);
    }
}
