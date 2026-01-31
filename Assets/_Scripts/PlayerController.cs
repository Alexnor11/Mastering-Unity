using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidBody;
    [SerializeField, Tooltip("Acceleration")] private float _movementAcceleration = 2;
    [SerializeField, Tooltip("VelocityMax")] private float _movementVelocityMax = 2;
    [SerializeField, Tooltip("Friction")] private float _movementFriction = 0.1f;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 curSpeed = _rigidBody.velocity;

        if (Input.GetKey(KeyCode.RightArrow))
            curSpeed.x += (_movementAcceleration * Time.deltaTime);
        if(Input.GetKey(KeyCode.LeftArrow))
            curSpeed.x -= (_movementAcceleration * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow))
            curSpeed.z += (_movementAcceleration * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            curSpeed.z -= (_movementAcceleration * Time.deltaTime);


        if (Input.GetKey(KeyCode.RightArrow) == Input.GetKey(KeyCode.LeftArrow))
            curSpeed.x -= (_movementFriction * curSpeed.x);

        if (Input.GetKey(KeyCode.UpArrow) == Input.GetKey(KeyCode.DownArrow))
           curSpeed.z -= (_movementFriction * curSpeed.z);

        curSpeed.x = Mathf.Clamp(curSpeed.x, _movementVelocityMax * -1, _movementVelocityMax);
        curSpeed.z = Mathf.Clamp(curSpeed.z, _movementVelocityMax * -1, _movementVelocityMax);

        _rigidBody.velocity = curSpeed;
    }
}
