using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidBody;
    [SerializeField, Tooltip("Ускорение")] private float _movementAcceleration = 2;
    [SerializeField, Tooltip("Максимальная скорость")] private float _movementVelocityMax = 2;
    [SerializeField, Tooltip("Замедление")] private float _movementFriction = 0.1f;
    [SerializeField] private float _jumpVelocity = 20;
    [SerializeField] private float _extraGravity = 40;

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

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(curSpeed.y) < 1)
            curSpeed.y += _jumpVelocity;
        else
            curSpeed.y -= _extraGravity * Time.deltaTime;

        curSpeed.x = Mathf.Clamp(curSpeed.x, _movementVelocityMax * -1, _movementVelocityMax);
        curSpeed.z = Mathf.Clamp(curSpeed.z, _movementVelocityMax * -1, _movementVelocityMax);

        _rigidBody.velocity = curSpeed;
    }
}
