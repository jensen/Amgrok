using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {
	public float bulletSpeed = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, bulletSpeed * Time.deltaTime, 0);
	}
}
