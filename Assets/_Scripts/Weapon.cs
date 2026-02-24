using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	GameObject _attachmentParent;
	[SerializeField, Tooltip("Приостановить движение после атаки?")]
	float _pauseMovementMax = 1.0f;
	float _pauseMovementTimer = 0.0f;

    [SerializeField, Tooltip("Снаряд для стрельбы пулями")]
    private GameObject _bulletToSpawn;

    [SerializeField, Tooltip("Анимация для воспроизведения при атаке")]
    public string _attackAnim = "SwordAttack01";

    [SerializeField, Tooltip("Звук, воспроизводимый при использовании оружия")]
    public AudioClip _attackSoundFX = null;

    private void Update()
    {
        if(_pauseMovementTimer > 0f)
        {
            _pauseMovementTimer -= Time.deltaTime;
            //return; // временно
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
        // воспроизведение звукового эффекта "attack"
        SpawnedSoundFX.Spawn(transform.position, _attackSoundFX);

        // приостановка движения
        _pauseMovementTimer = _pauseMovementMax;

        // обработка логики "оружия со снарядами"
        if (_bulletToSpawn)
        {
            GameObject newBullet = Instantiate(_bulletToSpawn, transform.position, Quaternion.identity);
            Bullet bullet = newBullet.GetComponent<Bullet>();
            if (bullet)
            {
                bullet.SetDirection(new Vector3(facing.x, 0f, facing.z));
            }
        }

    }
}
