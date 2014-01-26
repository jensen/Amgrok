using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	public SpriteRenderer _spriteRenderer;

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
	public int shotNumber = 1;

	private float _nextFire;

	void Start () {
		var go = new GameObject(gameObject.name + " Sprite");

		go.transform.parent = transform;
		go.transform.localPosition = Vector3.zero;
		go.transform.localRotation = Quaternion.identity;
		go.transform.localScale = Vector3.one;

		_spriteRenderer = go.AddComponent<SpriteRenderer>();
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
		//SpriteRenderer sr = GetComponent ("SpriteRenderer") as SpriteRenderer;

		if (horiz < 0) {
			_spriteRenderer.sprite = tiltL;
		} else if (horiz > 0) {
			_spriteRenderer.sprite = tiltR;
		} else {
			_spriteRenderer.sprite = untilt;
		}

		transform.Translate (horiz, 0, 0);
		transform.Translate (0, vert, 0);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), Mathf.Clamp(transform.position.y, topBorder, bottomBorder), transform.position.z);

		_spriteRenderer.gameObject.transform.rotation = GetDirection();
	}

	public void AddHealth(float amount) {
		health = Mathf.Clamp(health + amount, 0, maxHealth);
	}

	public void ReduceHealth(float amount) {
		ScreenShake.Instance.shakingTimer = 0.2f;
		health = Mathf.Clamp(health - amount, 0, maxHealth);
		if(health <= 0.0f)
		{
			SoundEffectsManager.Instance.PlayDeathSound();
			ParticleEffectsManager.Instance.PlayExplosionEffect(transform.position);

			// Show end screen.
			transform.parent.gameObject.AddComponent<GameOverMenu>();
			DestroyObject(gameObject);
		}
		else
		{
			SoundEffectsManager.Instance.PlayHitSound();
		}
	}

	void Shoot () {
		SoundEffectsManager.Instance.PlayShootSound();
		for (int i = 1; i <= shotNumber; i++) {
						var blt = (Bullet)Instantiate (bullet, transform.position, Quaternion.identity); 
						float ang = -Mathf.PI / 4 + Mathf.PI / 2 * i / (shotNumber + 1);
						blt.direction = GetDirection () * (new Vector2 (Mathf.Sin (ang), Mathf.Cos (ang)));
				}
	}

	public Quaternion GetDirection() {
		return Quaternion.AngleAxis(shootingDirection * 90, new Vector3(0, 0, 1));
	}

	public void RotateRight() {
		shootingDirection --;
	}
	
	public void RotateLeft() {
		shootingDirection ++;
	}
}
