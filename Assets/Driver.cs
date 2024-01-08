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
        transform.Rotate(0,0,turnSpeed);
        transform.Translate(0,movementSpeed,0);
    }
}
