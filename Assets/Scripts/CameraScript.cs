using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float movementSpeed = 2f;

    void FixedUpdate()
    {

        if (Input.GetKey("up") && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("down"))
        {
            transform.position -= transform.TransformDirection(Vector3.up) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("left"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("right"))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
    }
}

