using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.05f;
    [SerializeField] float turnSpeed = 0.5f;
    [SerializeField] float accelerationDelay = 0.5f;

    PlayerInput playerInput;
    InputAction moveAction;
    Vector2 currentInputVector;
    Vector2 smoothInputVelocity;

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
        currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, accelerationDelay);
        Vector2 smoothedInput = new Vector2(currentInputVector.x, currentInputVector.y);

        float acceleration = smoothedInput.y * movementSpeed * Time.deltaTime;
        float turning = smoothedInput.x * turnSpeed * Time.deltaTime;

        transform.Translate(0, acceleration, 0);

        if (input.y >= 0)
        {
            transform.Rotate(0, 0, -turning);
        }
        else
        {
            transform.Rotate(0, 0, turning);
        }
    }
}
