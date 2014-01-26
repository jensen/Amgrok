using UnityEngine;
using System.Collections;

/// <summary>
/// Splitter instantiates this object to create duplicates
/// </summary>
public class DelayedSplit : MonoBehaviour {
	public Enemy prefab;
	public float splitDelay = 0.2f;
	public Vector2 relativeSpeed;
	public Vector2 splitSpeed = new Vector2(1.2f, 0);
	
	IEnumerator Start() {
		yield return new WaitForSeconds(splitDelay);

		var left = (Enemy) Instantiate(prefab, transform.position, transform.rotation);
		left.speed = relativeSpeed - splitSpeed;
		
		var right = (Enemy) Instantiate(prefab, transform.position, transform.rotation);
		right.speed = relativeSpeed + splitSpeed;

		Destroy(gameObject);
	}
}
