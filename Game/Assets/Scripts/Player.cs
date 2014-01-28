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
	public float bombReloadTime = 2;
	public float bombDelay = 0.3F;
	public bool crazyFire = false;
	public int killCount = 0;
	public float craziness = .4F;
	public float crazySpeedup = .5F;
	public float damageMult = 1F;
	public float damageMultEasy = 0.75F;
	public float damageMultMed = 1F;
	public float damageMultHard = 1.5F;
	public int bomb = 0;
	public int bombParts = 0;
	public int bombPartsNeeded = 2;
	public int bombPartsNeededEasy = 1;
	public int bombPartsNeededMed = 2;
	public int bombPartsNeededHard = 4;
	public int maxBombs = 3;
	public float health = 100;
	public float maxHealth = 100;

	/// <summary>
	/// The shooting direction: 0, 1, 2, 3.
	/// </summary>
	public int shootingDirection = 0;
	public int shotNumber = 1;

	private float _nextFire;
	private float _nextBomb;
	public bool _bombing;
	private Vector3 _bomb_position;

	public void incrementShotNumber () {
		if (shotNumber < 99) {
						shotNumber += 1;
				}
		}
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
		if (_bombing && Time.time > _nextBomb) {
			_bombing = false;
			_nextBomb = bombReloadTime + Time.time;
			Bomb ();
		}
		if (Input.GetKey (KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.Z)) {

			if (Time.time > _nextFire) {
				if (crazyFire) {
					_nextFire = fireDelay * crazySpeedup + Time.time;
				} else {
					_nextFire = fireDelay + Time.time;
				}
				Shoot ();
			}
		}
		if (Input.GetKey (KeyCode.X) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
				if (Time.time > _nextBomb && bomb >= 1) {
					bomb -= 1;
					_nextBomb = bombDelay + Time.time;
					_bombing = true;
					LevelManager.Instance.hud.Change ();
					_bomb_position = transform.position;
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
		ParticleEffectsManager.Instance.PlayHealingEffect (transform.position);
		health = Mathf.Clamp(health + amount, 0, maxHealth);
		ParticleEffectsManager.Instance.PlayHealEffect(transform.position);

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

			GameObject gameOver = GameObject.Find("Game Over");
			gameOver.GetComponent<SpriteRenderer>().enabled = true;

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
			float ang;
			if (crazyFire) {
				 ang = -Mathf.PI / 4 + Mathf.PI / 2 * i / (shotNumber + 1) + Random.Range (-craziness,craziness);
			} else {
				ang = -Mathf.PI / 4 + Mathf.PI / 2 * i / (shotNumber + 1);
			}
			blt.direction = GetDirection () * (new Vector2 (Mathf.Sin (ang), Mathf.Cos (ang)));
		}
	}

	public void getBomb() {
		if (bombParts < bombPartsNeeded - 1) {
						bombParts += 1;
				} else if (bombParts == bombPartsNeeded - 1 && bomb < maxBombs) {
			bomb += 1;
			bombParts = 0;
				}
	}

	void Bomb () {
		Enemy[] allEnemies = FindObjectsOfType<Enemy>() as Enemy[];
		foreach (Enemy e in allEnemies) {
			e.BombDestroy();
		}
		ParticleEffectsManager.Instance.PlayBombEffect (_bomb_position);
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
