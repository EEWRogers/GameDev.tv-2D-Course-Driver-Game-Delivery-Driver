using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    [SerializeField] PackageType packageType;
    public PackageType PackageType { get { return packageType; } }

    SpriteRenderer spriteRenderer;

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable() 
    {
        switch (packageType)
        {
            case PackageType.RED:
            spriteRenderer.color = Color.red;
            break;


            case PackageType.GREEN:
            spriteRenderer.color = Color.green;
            break;

            case PackageType.BLUE:
            spriteRenderer.color = Color.blue;
            break;

            default:
            spriteRenderer.color = Color.white;
            break;
        }
    }

}
