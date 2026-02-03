using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	[SerializeField] float _shake = 0.05f;
	Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        Vector3 newPosition = new Vector3();
        newPosition.x = _startPos.x + Random.Range(-_shake, _shake);
        newPosition.y = _startPos.y + Random.Range(-_shake, _shake);
        newPosition.z = _startPos.z + Random.Range(-_shake, _shake);
        transform.position = newPosition;
    }
}
