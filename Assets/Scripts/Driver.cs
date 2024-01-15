using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float movementSpeed = 15f;
    [SerializeField] float boostedSpeed = 20f;
    [SerializeField] float boostTime = 3f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float slowTime = 3f;
    [SerializeField] float turnSpeed = 150f;
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

    void Update()
    {
        MovePlayer();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.GetComponent<Boost>() == null) { return; }

        StartCoroutine(BoostPlayer());
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        StartCoroutine(SlowPlayer());
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

    IEnumerator BoostPlayer()
    {
        float currentSpeed = movementSpeed;

        movementSpeed = boostedSpeed;

        yield return new WaitForSeconds(boostTime);

        movementSpeed = currentSpeed;
    }

    IEnumerator SlowPlayer()
    {
        float currentSpeed = movementSpeed;

        movementSpeed = slowSpeed;

        yield return new WaitForSeconds(slowTime);

        movementSpeed = currentSpeed;
    }
}
