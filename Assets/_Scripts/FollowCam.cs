using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
	[SerializeField, Tooltip("Объект для следования")]
	private GameObject _camTarget;

	[SerializeField, Tooltip("Смещение цели")]
	private Vector3 _targetOffset;
	
	[SerializeField, Tooltip("Высота от земли")] 
	private float _camHeigth = 9;
	
	[SerializeField, Tooltip("Расстояние до цели")] 
	float _camDistance = -16;

    private void Update()
    {
        if(!_camTarget)
			return;

		Vector3 targetPos = _camTarget.transform.position;
		targetPos += _targetOffset;
		targetPos.y += _camHeigth;
		targetPos.z += _camDistance;
		// перемещение камеры к целевой позиции
		Vector3 camPos = transform.position;
		transform.position = Vector3.Lerp(camPos, targetPos, Time.deltaTime * 5.0f);

    }
}
