using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class HomingMissile : MonoBehaviour {
	private Enemy _enemy;

	public float speed = 3;

	void Start() {
		_enemy = GetComponent<Enemy>();
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
