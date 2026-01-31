using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidBody;
	private float _muvementAcceleration = 2;
	private float _muvementVelocityMax = 2;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 curSpeed = _rigidBody.velocity;

        if (Input.GetKey(KeyCode.RightArrow))
            curSpeed.x += _muvementAcceleration * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
            curSpeed.x -= _muvementAcceleration * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
            curSpeed.z += _muvementAcceleration * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
            curSpeed.z -= _muvementAcceleration * Time.deltaTime;

        curSpeed.x = Mathf.Clamp(curSpeed.x, _muvementVelocityMax * -1, _muvementVelocityMax);
        curSpeed.z = Mathf.Clamp(curSpeed.z, _muvementVelocityMax * -1, _muvementVelocityMax);

        _rigidBody.velocity = curSpeed;
    }
}
