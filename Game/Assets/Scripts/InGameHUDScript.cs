using UnityEngine;
using System.Collections;

public class InGameHUDScript : MonoBehaviour {
	
	public float displayHealth = 100;

	private GameObject healthBar;
	//private GameObject nextEnemy;

	private Vector3 healthScale;

	// Use this for initialization
	void Start () {
		healthScale = new Vector3(1.0f, 1.0f, 1.0f);

		healthBar = GameObject.Find("HealthBar");
		//nextEnemy = GameObject.Find("NextEnemy");

		if(healthBar == null)
		{
			Debug.LogError("HealthBar doesn't exist.");
		}

		//SetHealth(20);
		SetNextSpawnHint(1);
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
	}

	/*public void SetHealth(float h) {
		targetHealth = h;

		ParticleEffectsManager.Instance.PlayExplosionEffect(healthBar.transform.position);
	}*/

	public void SetNextSpawnHint(int type) {

	}
}
