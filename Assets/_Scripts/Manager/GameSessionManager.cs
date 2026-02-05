using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionManager : MonoBehaviour
{
	[Tooltip("Оставшиеся жизни игрока")]
	private int _playerLives = 3;
	[SerializeField, Tooltip("Место возраждение игрока")]
	private Transform _respawnLocation;
	[SerializeField] private GameObject _gameOverObj;
	[SerializeField] float _returnToMenuCountdown = 0;

	static public GameSessionManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(_returnToMenuCountdown > 0)
		{
			_returnToMenuCountdown -= Time.deltaTime;
			if(_returnToMenuCountdown < 0)
			{
				SceneManager.LoadScene("TitleMenu");
			}
		}
    }

    public void OnPlayerDeath(GameObject player)
	{
		if (_playerLives <= 0)
		{
			GameObject.Destroy(player.gameObject);
			Debug.Log("Game over!");
            
			_gameOverObj.SetActive(true);
            _returnToMenuCountdown = 4;
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
