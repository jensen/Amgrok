using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class MovementReverser : MonoBehaviour {
	private Enemy _enemy;
	private Vector2 _prevSpeed;

	public float lowPass = 5f;
	public float speed = 0.5f;
	
	void Start() {
		_enemy = GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
		//float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
		//float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
		//float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
		//float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

		var newSpeed = Random.insideUnitCircle * speed;
		var filteredSpeed = Vector2.MoveTowards(_prevSpeed, newSpeed, lowPass * Time.deltaTime);

		_enemy.speed = filteredSpeed;

		_prevSpeed = filteredSpeed;

		//transform.Translate ((float) ((Random.value - 0.5) * Random.value * speed), (float) ((Random.value - 0.5) * Random.value * speed), 0F);
		//transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), Mathf.Clamp(transform.position.y, topBorder, bottomBorder), transform.position.z);
	}	

	void OnCollisionEnter(Collision c) {
		if (c.collider.gameObject.GetComponent<BulletMovement>() != null) {
			DestroyImmediate(gameObject);
		}
	}
}
