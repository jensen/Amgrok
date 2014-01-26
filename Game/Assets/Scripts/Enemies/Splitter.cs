using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class Splitter : MonoBehaviour {
	public DelayedSplit delayedSplit;
	public float splitDelay = 0.2f;
	public Vector2 splitSpeed = new Vector2(1.2f, 0);

	private Enemy _enemy;

	void Awake() {
		_enemy = GetComponent<Enemy>();
	}

	void OnShotByPlayer() {
		var ds = (DelayedSplit) Instantiate(delayedSplit);
		ds.transform.position = transform.position;
		ds.transform.rotation = transform.rotation;

		ds.relativeSpeed = _enemy.speed;
		ds.splitDelay = splitDelay;
		ds.splitSpeed = splitSpeed;
	}
}
