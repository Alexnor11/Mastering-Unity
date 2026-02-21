using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	GameObject _attachmentParent;
	[SerializeField, Tooltip("Приостановить движение после атаки?")]
	float _pauseMovementMax = 1.0f;
	float _pauseMovementTimer = 0.0f;

    private void Update()
    {
        if(_pauseMovementTimer > 0f)
        {
            _pauseMovementTimer -= Time.deltaTime;
            return; // временно
        }
        if (_attachmentParent)
        {
            // изменение положения gfx оружия по отношению к тому, кто
            // экипирован этим оружием
            Transform tr = _attachmentParent.transform;
            transform.position = tr.position;
            transform.localEulerAngles = tr.eulerAngles;
        }
    }
    public void SetAttachmentParent(GameObject parentObj)
    {
        _attachmentParent = parentObj;
    }

    public bool IsMovmentPaused()
    {
        return(bool)(_pauseMovementTimer > 0);
    }

    public void onAttack(Vector3 facing)
    {
        // код: обработка логики "взмах меча"
        // код: обработать логику "выстрел из бластера"
    }
}
