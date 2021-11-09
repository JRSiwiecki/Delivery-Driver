using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 225f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 20f;

    float timer = 0f;
    int seconds = 0;
    
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;     
        
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        timer += Time.deltaTime;
        seconds = (int) (timer % 60);

        if (seconds == 2)
        {
            moveSpeed = 15f;
        } 
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        timer = 0;
        seconds = 0;
        moveSpeed = slowSpeed;
        Debug.Log("You hit an obstacle!");
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        /*if (other.tag == "Bump")
        {
            timer = 0;
            seconds = 0;
            moveSpeed = slowSpeed;
            Debug.Log("You hit a speed bump!");
        }*/

        if (other.tag == "Boost")
        {
            timer = 0;
            seconds = 0;
            moveSpeed = boostSpeed;
            Debug.Log("You hit a speed boost!");
        }
    }
}
