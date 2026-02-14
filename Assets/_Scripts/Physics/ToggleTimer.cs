using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTimer : MonoBehaviour
{
	[SerializeField] float _curTimer = 0;
	[SerializeField] float _timerGoal = 3;
	[SerializeField] List<GameObject> _toggleObj;

    private void Update()
    {
        if( _toggleObj == null)
        {
            return;
        }
        _curTimer += Time.deltaTime;
        if(_curTimer > _timerGoal )
        {
            _curTimer = 0;
            // перебор объектов и их включение/выключение
            for(int i = 0;  i < _toggleObj.Count; i++)
            {
                bool newVal = !_toggleObj[i].activeSelf;
                _toggleObj[i].SetActive(newVal);
            }
        }
    }
}
