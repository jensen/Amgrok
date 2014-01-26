using UnityEngine;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Spawn zone for enemies.
/// </summary>
public class Spawning : MonoBehaviour {

	public const int numSprites = 5;

	public char[] charCodes = new char[5] {'A','B','C','D','E'};
	public Sprite[] spriteSet = new Sprite[numSprites];

	public GameObject[] units = new GameObject[numSprites];

	public Rect spawnZone = new Rect(-10, -10, 10, 10);

	/// Determines minimum spawn delay
	public float spawnRateMin = 1;
	/// Determines maximum spawn delay
	public float spawnRateMax = 2;

	private float _nextSpawn;
	private Dictionary<char, Sprite> _spriteDict;

	void Start() {

		spriteSet = spriteSet.OrderBy(c => System.Guid.NewGuid()).ToArray();

		_spriteDict = new Dictionary<char, Sprite>();
		for (int i = 0; i < charCodes.Length; i ++) {
			_spriteDict.Add(charCodes[i], spriteSet[i]);
		}

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
		Instantiate(units[Random.Range(0, numSprites)], GetSpawnPosition(), Quaternion.identity); 
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
