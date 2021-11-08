using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // The camera's position should follow the car's position.
    [SerializeField] GameObject followObject;

    void Update()
    {
        transform.position = followObject.transform.position + Vector3.back;
    }
}
