using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float bulletSpeed = 20;
	public float destroyTime = 5;
	public Vector2 direction = Vector3.up;

	void Start () {
		Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (Vector3) (direction * (bulletSpeed * Time.deltaTime));
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.GetComponent<Enemy>() != null)
			Destroy(gameObject);
	}
}

