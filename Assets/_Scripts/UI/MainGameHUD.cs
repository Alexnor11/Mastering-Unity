using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameHUD : MonoBehaviour
{
	[SerializeField, Tooltip("текущее состояние здоровья")]
	TextMeshProUGUI _healthValueText;

	[SerializeField, Tooltip("количество собранных монет")]
	TextMeshProUGUI _coinValueText;

	[SerializeField, Tooltip("оставшиеся жизни")]
	TextMeshProUGUI _livesValueText;

	[SerializeField, Tooltip("Health Manager")]
	HealthManager _healthManager;

    private void Update()
    {
		int curHealth = Mathf.RoundToInt(_healthManager.GetHealthCur());
		int maxHealth = Mathf.RoundToInt(_healthManager.GetHealthMax());
		_healthValueText.text = curHealth + "/" + maxHealth;

		_coinValueText.text = GameSessionManager.Instance.GetCoins().ToString();
		_livesValueText.text = GameSessionManager.Instance.GetLives().ToString();
    }
}
