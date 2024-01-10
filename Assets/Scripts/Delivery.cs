using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] PackageType currentPackage;

    void OnEnable() 
    {
        currentPackage = PackageType.EMPTY;
    }

    void OnTriggerEnter2D(Collider2D other)
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
