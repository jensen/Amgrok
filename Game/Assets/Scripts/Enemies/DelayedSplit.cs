using UnityEngine;
using System.Collections;

/// <summary>
/// Splitter instantiates this object to create duplicates
/// </summary>
public class DelayedSplit : MonoBehaviour {
	public Enemy prefab;
	public float splitDelay = 0.2f;
	public Vector2 relativeSpeed;
	public float splitSpeed = 1;
	
	IEnumerator Start() {
		yield return new WaitForSeconds(splitDelay);
		float splitAngle = Random.Range (0F, Mathf.PI*2);
		var left = (Enemy) Instantiate(prefab, transform.position, transform.rotation);
		left.speed = splitSpeed * (new Vector2 (Mathf.Cos (splitAngle), Mathf.Sin (splitAngle)));

		var right = (Enemy) Instantiate(prefab, transform.position, transform.rotation);
		right.speed = splitSpeed * (new Vector2(-Mathf.Cos (splitAngle), -Mathf.Sin (splitAngle)));

		/*
		var left = (Enemy) Instantiate(prefab, transform.position, transform.rotation);
		left.speed = relativeSpeed + Vector2.Scale(new Vector2(-1, 1), splitSpeed);
		
		var right = (Enemy) Instantiate(prefab, transform.position, transform.rotation);
		right.speed = relativeSpeed + splitSpeed;*/

		Destroy(gameObject);
	}
}
