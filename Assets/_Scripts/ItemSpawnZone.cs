using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnZone : MonoBehaviour
{
	[SerializeField] private GameObject _itemToSpawn;
	[SerializeField] private float _itemCount = 30;
	[SerializeField] private BoxCollider _spawnZone;
    [SerializeField , Tooltip("Как организовать объекты при создании?")]    
    private SpawnShare _spawnShare;

    private enum SpawnShare
    {
        Random,
        Circle,
        Grid,
        Count
    }

    
    [SerializeField, Tooltip("Скорость вращения")]
    private Vector3 _rotationSpeed;


    private void Start()
    {
        if(_spawnShare == SpawnShare.Circle)
        {
            SpawnObjectInCircle();
        }
        else
        {
            for (int i = 0; i < _itemCount; i++)
            {
                SpawnItemAtRandomPosition();
            }
        }        
    }

    private void Update()
    {
        Vector3 newRot = transform.localEulerAngles;
        newRot += _rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = newRot;
    }

    void SpawnItemAtRandomPosition()
    {
        Vector3 randomPos;
        randomPos.x = Random.Range(_spawnZone.bounds.min.x, _spawnZone.bounds.max.x);
        randomPos.y = Random.Range(_spawnZone.bounds.min.y, _spawnZone.bounds.max.y);
        randomPos.z = Random.Range(_spawnZone.bounds.min.z, _spawnZone.bounds.max.z);

        Instantiate(_itemToSpawn, randomPos, Quaternion.identity);
    }
    /// <summary>
    /// Радиус определяется размером коллайдера зоны появления.
    /// <summary>
    void SpawnObjectInCircle()
    {
        float radius = _spawnZone.bounds.size.x / 2;
        Transform parent = this.gameObject.transform;
        for (int i = 0; i < _itemCount; ++i)
        {
            // получение позиции на окружности, чтобы создать объект
            float angel = i * Mathf.PI * 2 / _itemCount;
            Vector3 pos = Vector3.zero;
            pos.x = Mathf.Cos(angel);
            pos.z = Mathf.Sin(angel);
            pos *= radius;
            pos += _spawnZone.bounds.center;
            // создание в качестве дочернего объекта родительского объекта
            GameObject newObj = Instantiate(_itemToSpawn, parent);
            newObj.transform.localPosition = pos;
        }
    }
}
