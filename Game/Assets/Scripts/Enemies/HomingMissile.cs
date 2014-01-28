using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class HomingMissile : MonoBehaviour {
	private Enemy _enemy;
	public float lifetime = 8F;
	public float speed = 3;

	void Start() {
		_enemy = GetComponent<Enemy>();
	}
	
	void OnDestroyed() {
		if (LevelManager.Instance.player != null) {
			if (LevelManager.Instance.player.shootingDirection == 3) {
				LevelManager.Instance.player.shootingDirection = 0;
			} else {
				LevelManager.Instance.player.shootingDirection += 1;
			}
		}
	}

	void OnTouchPlayer() {
		if (LevelManager.Instance.player != null) {
			if (LevelManager.Instance.player.shootingDirection == 0) {
				LevelManager.Instance.player.shootingDirection = 3;
			} else {
				LevelManager.Instance.player.shootingDirection -= 1;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0F) {
			ParticleEffectsManager.Instance.PlayExplosionEffect(gameObject.transform.position);
			Destroy(gameObject);
				}
		if (LevelManager.Instance.player != null) {
						Vector2 relative = (LevelManager.Instance.player.transform.position - transform.position);
								_enemy.speed = speed * relative.normalized;
				}
	}
}
