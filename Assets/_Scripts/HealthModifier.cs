using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthModifier : MonoBehaviour
{
	[SerializeField, Tooltip("Изменение здоровья")]
	float _healthChange = 0;
	
	[SerializeField, Tooltip("Класс объекта, который должен быть поврежден")]	
	DamageTarget _applyToTarget = DamageTarget.Player;
	
	public enum DamageTarget
	{
		Player,
		Enemies,
		All,
		None
	}
	[SerializeField] bool _destroyOnCollision = false;

    private void Update()
    {
        
    }
    void OnTriggerStay(Collider collision)
    {
        GameObject hitObj = collision.gameObject;
        HealthManager healthManager = hitObj.GetComponent<HealthManager>();
        if (healthManager && IsValidTarget(hitObj))
        {
            healthManager.AdjustCurHealth(_healthChange);
            if (_destroyOnCollision)
                GameObject.Destroy(gameObject);
        }
    }

    bool IsValidTarget(GameObject possibleTarget)
	{
		if (_applyToTarget == DamageTarget.All)
			return true;
		else if (_applyToTarget == DamageTarget.None)
			return false;
		else if (_applyToTarget == DamageTarget.Player &&
			possibleTarget.GetComponent<PlayerController>())
			return true;
		else if(_applyToTarget == DamageTarget.Enemies && 
			possibleTarget.GetComponent<AIBrain>())
			return true;
		return false;
	}
}
