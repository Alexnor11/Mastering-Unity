using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObjectController : MonoBehaviour
{
    float speed = 15f;

    private void Update()
    {
        Vector3 newRotation = transform.localEulerAngles;

        if(Input.GetKey(KeyCode.RightArrow))
            newRotation.z -= speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftArrow))
            newRotation.z += speed * Time.deltaTime;

        if( Input.GetKey(KeyCode.UpArrow))
            newRotation.x += speed * Time.deltaTime;

        if(Input .GetKey(KeyCode.DownArrow))
            newRotation.x -= speed * Time.deltaTime;

        transform.localEulerAngles = newRotation;
    }
}
