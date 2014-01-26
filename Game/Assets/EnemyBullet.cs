using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyBullet : MonoBehaviour {
	public float bulletSpeed = 20;
	public float destroyTime = 5;
	public Vector2 direction = Vector3.down;
	
	void Start () {
		Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (Vector3) (direction * (bulletSpeed * Time.deltaTime));
	}
	
	void OnTouchPlayer () {
		if (LevelManager.Instance.player != null) {
			LevelManager.Instance.player.crazyFire = false;
		}
	}
}

