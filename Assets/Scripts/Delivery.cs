using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collided with something!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package")
        {
            if (!hasPackage)
            {
                Debug.Log("Picked up package!");
                hasPackage = true;
            }

            else 
            {
                Debug.Log("You already have a package!");
            }
        }


        else if (other.tag == "Customer")
        {
            if (hasPackage)
            {
                Debug.Log("Delivered package!");
                hasPackage = false;
            }

            else
            {
                Debug.Log("No package to deliver!");
            }
        }
    }
}
