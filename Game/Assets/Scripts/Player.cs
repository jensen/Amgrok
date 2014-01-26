using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Player : MonoBehaviour {

	public Sprite tiltR;
	public Sprite tiltL;
	public GameObject bullet; 
	public Sprite untilt;
	public float horizSpeed = 10;
	public float vertSpeed = 10;
	public float fireDelay = 1;

	public float health = 100;
	public float maxHealth = 100;

	private float _nextFire;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float horizInp = Input.GetAxis ("Horizontal");
		float horiz = horizInp * horizSpeed * Time.deltaTime;
		float vertInp = Input.GetAxis ("Vertical");
		float fireInp = Input.GetAxis ("Fire1");

		if (Input.GetKey (KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey (KeyCode.Space)) {
			if (Time.time > _nextFire) {
				_nextFire = fireDelay + Time.time;
				Shoot ();
			}
		}

		float vert = vertInp * vertSpeed * Time.deltaTime;
		float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
		float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
		float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
		float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
		SpriteRenderer sr = GetComponent ("SpriteRenderer") as SpriteRenderer;

		if (horiz < 0) {
			sr.sprite = tiltL;
		} else if (horiz > 0) {
			sr.sprite = tiltR;
		} else {
			sr.sprite = untilt;
		}

		transform.Translate (horiz, 0, 0);
		transform.Translate (0, vert, 0);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), Mathf.Clamp(transform.position.y, topBorder, bottomBorder), transform.position.z);

	}

	public void AddHealth(float amount) {
		health = Mathf.Clamp(health + amount, 0, maxHealth);
	}

	public void ReduceHealth(float amount) {
		health = Mathf.Clamp(health - amount, 0, maxHealth);
		SoundEffectsManager.Instance.PlayHitSound();
	}

	void Shoot () {
		SoundEffectsManager.Instance.PlayShootSound();
		Instantiate (bullet, transform.position, Quaternion.identity); 
	}
}
