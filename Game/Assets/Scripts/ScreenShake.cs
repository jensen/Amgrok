using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {
	public static ScreenShake Instance { get; private set; }

	public Vector3 regularPosition;
	public float frequency = 12;
	public float amplitude = 5;
	public float shakingTimer = 0;

	void Start() {
		Instance = this;
		regularPosition = transform.position;
	}

	void Update() {
		if (shakingTimer > 0) {
			transform.position = regularPosition
				+ amplitude * new Vector3(
					Mathf.PerlinNoise(1 * frequency * Time.time - 20, -1.2f * frequency * Time.time - 33),
					Mathf.PerlinNoise(-0.3f * frequency * Time.time - 32, 1 * frequency * Time.time - 13), 0);
			shakingTimer -= Time.deltaTime;
		} else {
			shakingTimer = 0;
			transform.position = regularPosition;
		}
	}
}
