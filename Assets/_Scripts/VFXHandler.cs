using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHandler : MonoBehaviour
{
	[SerializeField] GameObject _mainExplosionChunk;
	[SerializeField] GameObject _secondaryExplosionChunk;
	[SerializeField] int _minChunks = 10;
	[SerializeField] int _maxChunks = 20;
	[SerializeField] float _explosionForce = 1500;

	public  void SpawnExplosion()
	{
		int rand = Random.Range(_minChunks, _maxChunks);
		if (_mainExplosionChunk)
		{
			for (int i = 0; i < rand; i++)
			{
				SpawnSubObject(_mainExplosionChunk);
			}
			rand /= 2;
			if(_secondaryExplosionChunk)
			{
				for(int i = 0;i < rand; i++)
				{
					SpawnSubObject(_secondaryExplosionChunk);
				}
			}
		}
	}
	void SpawnSubObject(GameObject prefab)
	{
		Vector3 pos = transform.position;
		pos += Random.onUnitSphere * 0.8f;
		GameObject newObj = Instantiate(prefab, pos, Quaternion.identity);

        Rigidbody rb = newObj.GetComponent<Rigidbody>();
        rb?.AddExplosionForce(_explosionForce, transform.position, 1f);
    }
}
