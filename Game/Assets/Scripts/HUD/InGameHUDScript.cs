using UnityEngine;
using System.Collections;

public class InGameHUDScript : MonoBehaviour {
	
	private float displayHealth;
	private float displayEnemyCount;

	private GameObject healthBar;
	private GameObject enemyCountBar;

	private Vector3 healthScale;
	private Vector3 enemyCountScale;

	// Use this for initialization
	void Start () {
		healthScale = new Vector3(1.0f, 1.0f, 1.0f);
		enemyCountScale = new Vector3(1.0f, 1.0f, 1.0f);

		healthBar = GameObject.Find("HealthBar");
		enemyCountBar = GameObject.Find("EnemyCountBar");

		if(healthBar == null)
		{
			Debug.LogError("HealthBar doesn't exist.");
		}

		if(enemyCountBar == null)
		{
			Debug.LogError("EnemyCountBar doesn't exist.");
		}

		displayHealth = LevelManager.Instance.player.maxHealth;
		displayEnemyCount = LevelManager.Instance.spawning.spawnThreshold;

		Change();
	}

	public void Change() {
		BroadcastMessage("ChangeHUDElement");
	}
	
	// Update is called once per frame
	void Update () {
		var player = LevelManager.Instance.player;

		float currentHealth = player.health;
		float maxHealth = player.maxHealth;

		if (!Mathf.Approximately(displayHealth, currentHealth)) {
			displayHealth = Mathf.Lerp(displayHealth, currentHealth, 10 * Time.deltaTime);

			healthScale.x = displayHealth / maxHealth;
			healthBar.transform.localScale = healthScale;
		}

		var spawner = LevelManager.Instance.spawning;

		float maxEnemyCount = spawner.spawnThreshold;
		float currentEnemyCount = maxEnemyCount - spawner.tempSpawnCount;

		if (!Mathf.Approximately(displayEnemyCount, currentEnemyCount) && player != null) {
			displayEnemyCount = Mathf.Lerp(displayEnemyCount, currentEnemyCount, 10 * Time.deltaTime);
			
			enemyCountScale.x = displayEnemyCount / maxEnemyCount;
			enemyCountBar.transform.localScale = enemyCountScale;
		}
	}
}
