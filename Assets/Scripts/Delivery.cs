using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    
    bool hasPackage = false;
    int numberOfCustomers, packagesDelivered;
    
    SpriteRenderer playerSpriteRenderer;
    Color32 hasPackageColor = Color.magenta, happyCustomerColor = Color.green, noPackageColor = Color.white;
    
    void Start() 
    {
        numberOfCustomers = GameObject.FindGameObjectsWithTag("Customer").Length;
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collided with something!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        SpriteRenderer objectSpriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
        
        if (other.tag == "Package")
        {
            // pick up the package, destroy the object
            // change the player's color to green to show that they have a package
            if (!hasPackage)
            {
                Debug.Log("Package picked up!");
                hasPackage = true;
                Destroy(other.gameObject, destroyDelay);
                playerSpriteRenderer.color = hasPackageColor;
            }

            else 
            {
                Debug.Log("You already have a package!");
            }
        }


        else if (other.tag == "Customer")
        {
            // change the customer's color to green if a package has been delivered to them already.
            // change player color back to white to signify that they no longer have a package.
            if (hasPackage && !(objectSpriteRenderer.color == happyCustomerColor))
            {
                Debug.Log("Package delivered!");
                hasPackage = false;
                objectSpriteRenderer.color = happyCustomerColor;
                packagesDelivered++;
                playerSpriteRenderer.color = noPackageColor;
            }

            else if (other.gameObject.GetComponent<SpriteRenderer>().color == happyCustomerColor)
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
