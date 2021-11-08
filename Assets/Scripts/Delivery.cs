using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    
    bool hasPackage = false;
    int numberOfCustomers;
    int packagesDelivered;
    
    void Start() 
    {
        numberOfCustomers = GameObject.FindGameObjectsWithTag("Customer").Length;
    }
    
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
                Debug.Log("Package picked up!");
                hasPackage = true;
                Destroy(other.gameObject, destroyDelay);
            }

            else 
            {
                Debug.Log("You already have a package!");
            }
        }


        else if (other.tag == "Customer")
        {
            // change the customer's color to green if a package has been delivered to them already.
            if (hasPackage)
            {
                Debug.Log("Package delivered!");
                hasPackage = false;
                other.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                packagesDelivered++;
            }

            else if (other.gameObject.GetComponent<SpriteRenderer>().color == Color.green)
            {
                Debug.Log("A package has already been delivered to this customer!");
            }
            
            else
            {
                Debug.Log("You have no package to deliver!");
            }
        }

        else if (other.tag == "Finish")
        {
            if (packagesDelivered == numberOfCustomers)
            {
                Debug.Log("You have delivered all the packages! You win!");
            }

            else
            {
                Debug.Log("You haven't delivered all the packages yet!");
            }
        }
    }
}
