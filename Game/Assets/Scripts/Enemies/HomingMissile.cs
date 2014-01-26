using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class HomingMissile : MonoBehaviour {
	private Enemy _enemy;

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
		if (LevelManager.Instance.player != null) {
						Vector3 relative = (LevelManager.Instance.player.transform.position - transform.position);

						if (relative.magnitude < speed * Time.deltaTime) {
								_enemy.speed = speed * relative;
						} else {
								_enemy.speed = speed * relative.normalized;
						}
				}
	}
}
