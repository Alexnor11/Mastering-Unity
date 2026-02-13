using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhysicsForceZone : MonoBehaviour
{
	[SerializeField] float _forceToApply = 1;

    private void Awake()
    {
        CapsuleCollider c = GetComponent<CapsuleCollider>();

        if (c)
        {
            c.isTrigger = true;
        }
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }        
    }

    private void OnTriggerStay(Collider collider)
    {
        GameObject hitObj = collider.gameObject;
        if(hitObj != null)
        {
            Rigidbody rb = hitObj.GetComponent<Rigidbody>();
            Vector3 dir = transform.up;
            rb.AddForce(dir * _forceToApply);
        }
    }
}
