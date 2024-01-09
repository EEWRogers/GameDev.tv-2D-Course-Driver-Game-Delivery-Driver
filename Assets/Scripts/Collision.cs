using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("You crashed!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("You entered the trigger zone!");
    }

}
