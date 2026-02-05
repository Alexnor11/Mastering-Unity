using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
	[Tooltip("Оставшиеся жизни игрока")]
	private int _playerLives = 3;
	[SerializeField, Tooltip("Место возраждение игрока")]
	private Transform _respawnLocation;
	static public GameSessionManager Instance;

    private void Awake()
    {
        Instance = this;
    }

	public void OnPlayerDeath(GameObject player)
	{
		if (_playerLives <= 0)
		{
			GameObject.Destroy(player.gameObject);
			Debug.Log("Game over!");
		}
		else
		{
			_playerLives--;
			HealthManager playerHealth = player.GetComponent<HealthManager>();
			if (playerHealth)
			{
				playerHealth.Reset();
			}
			if(_respawnLocation)
			{
				player.transform.position = _respawnLocation.position;
			}
			Debug.Log("Player lives remaining: " + _playerLives);
		}
	}

	public int GetCoins() { return PickUpItem.s_objectsCollected; }
	public int GetLives() { return _playerLives; }
}
