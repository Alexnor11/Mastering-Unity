using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springboard : MonoBehaviour
{
	[SerializeField] float _upwardsForce = 2000f;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObj = collision.gameObject;
        if (hitObj != null)
        {
            Rigidbody rb = hitObj.GetComponent<Rigidbody>();
            rb?.AddForce(0, _upwardsForce, 0);
        }
    }
}
