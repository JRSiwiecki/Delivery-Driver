using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 225f;
    [SerializeField] float moveSpeed = 15f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        Debug.Log("Steer Amount: " + steerAmount);
        Debug.Log("Move Amount: " + moveAmount);
        
        if (moveAmount != 0)
        {
            transform.Rotate(0, 0, -steerAmount);
        }
        
        
        transform.Translate(0, moveAmount, 0);
    }
}
