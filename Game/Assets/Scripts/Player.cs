using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	public Sprite tiltR;
	public Sprite tiltL;
	public Bullet bullet; 
	public Sprite untilt;
	public float horizSpeed = 10;
	public float vertSpeed = 10;
	public float fireDelay = 1;

	public float health = 100;
	public float maxHealth = 100;

	/// <summary>
	/// The shooting direction: 0, 1, 2, 3.
	/// </summary>
	public int shootingDirection = 0;

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
		float leftBorder = LevelManager.Instance.levelBounds.xMin;
		float rightBorder = LevelManager.Instance.levelBounds.xMax;
		float topBorder = LevelManager.Instance.levelBounds.yMin;
		float bottomBorder = LevelManager.Instance.levelBounds.yMax;
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
		var blt = (Bullet) Instantiate (bullet, transform.position, Quaternion.identity); 
		blt.direction = Quaternion.AngleAxis(shootingDirection * 90, new Vector3(0, 0, 1)) * Vector2.up;
	}

	public void RotateRight() {
		shootingDirection --;
	}
	
	public void RotateLeft() {
		shootingDirection ++;
	}
}
