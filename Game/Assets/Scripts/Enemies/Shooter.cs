using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public float minShotDelay = 1F;
	public float maxShotDelay = 1.5F;
	public float minShotDelayEasy = 2F;
	public float maxShotDelayEasy = 2.5F;
	public float minShotDelayMed = .5F;
	public float maxShotDelayMed = 1F;
	public float minShotDelayHard = .25F;
	public float maxShotDelayHard = .5F;
	public float timeTillShot = 3F;
	public EnemyBullet bullet;
	// Use this for initialization
	void Start () {
		timeTillShot = Random.Range (minShotDelay,maxShotDelay);
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
