using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float bulletSpeed = 20;
	public float destroyTime = 5;

	void Start () {
		Destroy(this, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, bulletSpeed * Time.deltaTime, 0);
	}
}
