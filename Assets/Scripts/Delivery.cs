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
        if (other.GetComponent<PackagePickup>() == null) { return; }

        if (currentPackage == PackageType.EMPTY)
        {
            AddPackage(other.GetComponent<PackagePickup>().PackageType);
            other.GetComponent<PackagePickup>().DestroyPackage();
        }
    }

    void AddPackage(PackageType packageCollected)
    {
        currentPackage = packageCollected;
    }

}
