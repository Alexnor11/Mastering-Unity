using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float _speed = 4;
	[SerializeField] private Vector3 _direction = Vector3.zero;

    private void Update()
    {
        Vector3 newPos = transform.position;
        newPos += _direction * (_speed * Time.deltaTime);
        transform.position = newPos;
        //transform.Translate(0, 0, _speed * Time.deltaTime);        
    }
    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
        transform.LookAt(transform.position + _direction);
    }
}
