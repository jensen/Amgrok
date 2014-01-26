using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public float minShotDelay = 2F;
	public float maxShotDelay = 4F;
	public float timeTillShot = 3F;
	public EnemyBullet bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeTillShot -= Time.deltaTime;
		if (timeTillShot <= 0) {
			Shoot ();
			SoundEffectsManager.Instance.PlayShootSound();
			timeTillShot += Random.Range(minShotDelay,maxShotDelay);
				}
	}

	void OnDestroyed () {
		if (LevelManager.Instance.player != null) {
			LevelManager.Instance.player.crazyFire = !(LevelManager.Instance.player.crazyFire);
		}
	}
	
	void OnTouchPlayer () {
		if (LevelManager.Instance.player != null) {
			LevelManager.Instance.player.crazyFire = false;
		}
	}

	void Shoot() {
		Instantiate (bullet, transform.position, Quaternion.identity); 
	}
}
