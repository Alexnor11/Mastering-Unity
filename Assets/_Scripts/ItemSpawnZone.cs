using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnZone : MonoBehaviour
{
	[SerializeField] private GameObject _itemToSpawn;
	[SerializeField] private float _itemCount = 30;
	[SerializeField] private BoxCollider _spawnZone;

    private void Start()
    {
        for(int i = 0; i < _itemCount; i++)
        {
            SpawnItemAtRandomPosition();
        }

        void SpawnItemAtRandomPosition()
        {
            Vector3 randomPos;
            randomPos.x = Random.Range(_spawnZone.bounds.min.x, _spawnZone.bounds.max.x);
            randomPos.y = Random.Range(_spawnZone.bounds.min.y, _spawnZone.bounds.max.y);
            randomPos.z = Random.Range(_spawnZone.bounds.min.z, _spawnZone.bounds.max.z);

            Instantiate(_itemToSpawn, randomPos, Quaternion.identity);
        }
    }
}
