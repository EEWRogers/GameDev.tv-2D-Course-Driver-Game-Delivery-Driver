using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] PackageType currentPackage;

    SpriteRenderer spriteRenderer;
    Color defaultColour;

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColour = spriteRenderer.color;
    }

    void OnEnable() 
    {
        currentPackage = PackageType.EMPTY;
    }

    void Update()
    {
        SetCarColour();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        {
            GetPackage(other);

            DeliverPackage(other);
        }

        void GetPackage(Collider2D other)
        {
            if (other.GetComponent<PackagePickup>() == null) { return; }

            if (currentPackage == PackageType.EMPTY)
            {
                currentPackage = other.GetComponent<PackagePickup>().PackageType;
                other.GetComponent<PackagePickup>().DestroyPackage();
            }
        }

        void DeliverPackage(Collider2D other)
        {
            if (other.GetComponent<DeliveryZone>() == null) { return; }

            if (currentPackage == other.GetComponent<DeliveryZone>().PackageType)
            {
                Debug.Log("Package delivered!");
                currentPackage = PackageType.EMPTY;
            }
        }
    }

    void SetCarColour()
    {
        switch (currentPackage)
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
                spriteRenderer.color = defaultColour;
                break;
        }
    }
}
