using UnityEngine;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Spawn zone for enemies.
/// </summary>
public class Spawning : MonoBehaviour {

	public const int numEnemies = 5;
	//public char[] charCodes = new char[5] {'A','B','C','D','E'};

	public GameObject[] units = new GameObject[numEnemies];

	public Rect spawnZone = new Rect(-10, -10, 10, 10);

	/// Determines minimum spawn delay
	public float spawnRateMin = 1F;
	public float spawnRateMinEasy = 1.4F;
	public float spawnRateMinMed = 1F;
	public float spawnRateMinHard = 0.7F;
	/// Determines maximum spawn delay
	public float spawnRateMax = 2F;
	public float spawnRateMaxEasy = 2.8F;
	public float spawnRateMaxMed = 2F;
	public float spawnRateMaxHard = 1.4F;
	public int spawnCount = 0;
	public int spawnThreshold = 100;
	public int killThreshold = 100;

	private float _nextSpawn;
	private Dictionary<char, Sprite> _spriteDict;

	void Start() {

		/*_spriteDict = new Dictionary<char, Sprite>();
		for (int i = 0; i < charCodes.Length; i ++) {
			_spriteDict.Add(charCodes[i], spriteSet[i]);
		}*/

		_nextSpawn = Time.time + GetSpawnInterval();
	}

	void FixedUpdate() {
		if (Time.time > _nextSpawn) {
			Spawn ();
			_nextSpawn = Time.time + GetSpawnInterval();
		}
	}

	/// Spawn the next enemy.
	void Spawn() {
		Debug.Log ("Spawn");
		Instantiate(units[Random.Range(0, numEnemies)], GetSpawnPosition(), Quaternion.identity);
		spawnCount++;

		if (spawnCount > spawnThreshold) {
			if (LevelManager.Instance.player.killCount > killThreshold) {
				Application.LoadLevel("Violent");
			} else {
				Application.LoadLevel("Peaceful");

			}
			//end Game
		}
	}

	/// Gets the position of the next spawn.
	Vector2 GetSpawnPosition() {
		return new Vector2(Random.Range(spawnZone.xMin, spawnZone.xMax),
		                   Random.Range(spawnZone.yMin, spawnZone.yMax));
	}

	/// Get the time interval for the next spawn.
	float GetSpawnInterval() {
		return Random.Range(spawnRateMin, spawnRateMax);
	}

	void OnDrawGizmos() {
		Gizmos1.DrawRect(spawnZone, new Color(1, .5f, .1f, .4f));
	}
}
