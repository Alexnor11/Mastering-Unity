using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour
{
    #region ** члены класса **
    // текущий набор действий искусственного интеллекта
    UnityEvent _curAIDirective;

    [SerializeField] UnityEvent _defaultActions;
    [SerializeField] UnityEvent _alertedActions;
    [SerializeField] UnityEvent _huntActions;

    [SerializeField, Tooltip("Misc-паттерны движения искусственного интеллекта.")]
    public UnityEvent _miscPattern1Actions;
    public UnityEvent _miscPattern2Actions;
    public UnityEvent _miscPattern3Actions;

    // таймер для приостановки работы логики искусственного интеллекта
    float _pauseTimer = 0;

    // необходим быстрый доступ к объекту игрока
    PlayerController _playerObject = null;

    #endregion

    private void Start()
    {
        // нахождение объекта игрока в сцене
        _playerObject = GameObject.FindObjectOfType<PlayerController>();
        // установка действий по умолчанию
        _curAIDirective = _defaultActions;
    }

    private void Update()
    {
        if (UpdatePausedAI())
        {
            return;
        }
        _curAIDirective.Invoke();
    }
    bool UpdatePausedAI()
    {
        if(_pauseTimer > 0)
        {
            _pauseTimer -= Time.deltaTime;
            _pauseTimer = Mathf.Max(_pauseTimer, 0f);
        }
        return (bool)(_pauseTimer > 0); 
    }
    #region *** Состояние искусственного интеллекта ***
    public void SetState_Default()
    {
        _curAIDirective = _defaultActions;
    }
    
    public void SetState_Hunt()
    {
        _curAIDirective = _huntActions;
    }

    public void SetState_MiscPattern(int pattern)
    {
        /* Действия: Глава 14 */
    }
    #endregion

    #region *** События искусственного интеллекта ***
    public void Jamp(float force)
    {
        GetComponent<Rigidbody>()?.AddForce(new Vector3(0, force, 0));
    }

    public void AlertIfPlayerNearby(float distance)
    {
        if (CalcDistanceToPlayer() < distance)
            _alertedActions?.Invoke(); ;
    }

    public void PauseAI(float timeInMS)
    {
        _pauseTimer = timeInMS;
    }

    public void UseWeapon()
    {
        /* Действия: Глава 10 */
    }
    #endregion
}
