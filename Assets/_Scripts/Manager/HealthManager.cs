using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField, Tooltip("Максимальный уровень здоровья")]
    private float _healthMax = 10;
    [SerializeField, Tooltip("Текущее значение здоровья")]
    private float _HealthCur = 10;
    [SerializeField, Tooltip("Секунды невосприимчивости к урону")]
    private float _invincibilityFramesMax = 1;
    [SerializeField, Tooltip("Оставшиеся секунды невосприимчивости")]
    private float _invincibilityFramesCur = 0;
    [SerializeField, Tooltip("Мертв ли объект")]
    private bool _isDead = false;


    private void Update()
    {
        if (_invincibilityFramesCur > 0)
        {
            _invincibilityFramesCur -= Time.deltaTime;
            if (_invincibilityFramesCur < 0)
            {
                _invincibilityFramesCur = 0;
            }
        }

        // обработка видимости объекта
        if (GetComponent<MeshRenderer>())
        {
            if (_invincibilityFramesCur > 0)
            {
                if (GetComponent<MeshRenderer>().enabled == true)
                {
                    GetComponent<MeshRenderer>().enabled = false;
                }
                else
                {
                    GetComponent<MeshRenderer>().enabled = true;
                }
            } else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
        }
        //if(IsDead())
        //	GameObject.Destroy(gameObject);

        if (_isDead)
        {
            if (GetComponent<PlayerController>())
            {
                GameSessionManager.Instance.OnPlayerDeath(gameObject);
            }
            else
                GameObject.Destroy(gameObject);
        }

        // переключение дрожания камеры для игрока
        if (GetComponent<PlayerController>())
        {
            CameraShake camShake = Camera.main.GetComponent<CameraShake>();
            if (camShake)
            {
                camShake.enabled = (bool)(_invincibilityFramesCur > 0);
            }
        }

    }
    public float AdjustCurHealth(float change)
    {
        if (_invincibilityFramesCur > 0)
        {
            return _HealthCur;
        }
        _HealthCur += change;

        if (_HealthCur <= 0)
        {
            OnDeath();
        }
        else if (_HealthCur >= _healthMax)
        {
            _HealthCur = _healthMax;
        }

        if (change < 0 && _invincibilityFramesMax > 0)
        {
            _invincibilityFramesCur = _invincibilityFramesMax;
        }
        return _HealthCur;
    }

    void OnDeath()
    {
        if (_HealthCur > 0)
        {
            Debug.Log(gameObject.name + " считать мертвым до обнуления здоровья.");
        }
        _isDead = true;
    }

    public bool IsDead()
    {
        return _isDead;
    }

    public void Reset()
    {
        _isDead = false;
        _HealthCur = _healthMax;
        _invincibilityFramesCur = 0;
    }
}
