using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.05f;
    [SerializeField] float turnSpeed = 0.5f;

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
    }

    void MovePlayer()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        float acceleration = input.y * movementSpeed * Time.deltaTime;
        float turning = -input.x * turnSpeed * Time.deltaTime;

        transform.Translate(0, acceleration, 0);

        if (acceleration >= 0)
        {
            transform.Rotate(0, 0, turning);
        }
        else
        {
            transform.Rotate(0, 0, -turning);
        }
    }
}
