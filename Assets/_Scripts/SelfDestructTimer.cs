using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructTimer : MonoBehaviour
{
	[SerializeField]
	float _countdownTimer = 1.5f;

    private void Update()
    {
        _countdownTimer -= Time.deltaTime;
        if(_countdownTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
