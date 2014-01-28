using UnityEngine;
using System.Collections;

public enum BorderBehavior {
	/// Goes through border
	None,
	/// Bounce around border
	Bounce,
	/// Stop moving sideways on border
	Stop
}

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour {
	protected int shotsToKill;
	public int maxShotsToKill = 1;
	public float collisionDamage = 15;
	static public float speedMultiplier = 1F;
	static public float speedMultiplierEasy = 0.8F;
	static public float speedMultiplierMed = 1F;
	static public float speedMultiplierHard = 1.2F;
	/// Change this field to change the enemy's sprite
	public Sprite sprite;
	/// Speed of the enemy
	public Vector2 speed = new Vector2(0, -1);
	/// Set if true if this enemy got shot
	public bool gotShot = false;

	public bool touchedPlayer = false;

	public BorderBehavior borderBehavior = BorderBehavior.Bounce;

	private SpriteRenderer _sr;

	void Awake() {
		_sr = GetComponent<SpriteRenderer>();
		//collider2D.isTrigger = false;
	}

	void Start() {
		//gameObject.AddComponent<Rigidbody2D>();
		//rigidbody2D.isKinematic = true;
		shotsToKill = maxShotsToKill;
	}

	void Update() {
		if (sprite != null) _sr.sprite = sprite;
	}

	void OnTriggerEnter2D(Collider2D c) {
		Debug.Log ("Collision", c);
		var go = c.gameObject;
		var blt = go.GetComponent<Bullet>();
		var plr = go.GetComponent<Player>();

		if (blt != null) gotShot = true;
		if (plr != null) touchedPlayer = true;
	}

	void FixedUpdate() {
		// if enemy is got shot by the player
		if (gotShot) {
			BroadcastMessage("OnShotByPlayer", SendMessageOptions.DontRequireReceiver);

			Debug.Log ("Shot by player.");
			if (shotsToKill == 1) {
				ParticleEffectsManager.Instance.PlayExplosionEffect(gameObject.transform.position);
				BroadcastMessage("OnDestroyed", SendMessageOptions.DontRequireReceiver);
				LevelManager.Instance.player.killCount += 1;
				Destroy(gameObject);
				if (LevelManager.Instance != null) {
					LevelManager.Instance.hud.Change();
				}
				return;
			} else if (shotsToKill > 1) {
				shotsToKill --;
				gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,((float) shotsToKill)/((float)maxShotsToKill)); //*= new Color(1F,1F,((float) shotsToKill)/(((float)shotsToKill)+1F));
				gotShot = false;
			}
		}

		// if enemy is touching player
		if (touchedPlayer) {
			BroadcastMessage("OnTouchPlayer", SendMessageOptions.DontRequireReceiver);

			TouchPlayer();
			if (LevelManager.Instance != null) {
				LevelManager.Instance.hud.Change();
			}

			Debug.Log ("Touch player.");
			//Destroy(gameObject);
			return;
		}

		float xMin = LevelManager.Instance.levelBounds.xMin;
		float xMax = LevelManager.Instance.levelBounds.xMax;

		// deal with borders
		//if (transform.position.x <= xMin) transform.position.x = xMin + speed.x * Time.deltaTime;
		//if (transform.position.x >= xMax) transform.position.x = xMax - speed.x * Time.deltaTime;
		
		
		// update position
		transform.position += (Vector3) speed * speedMultiplier * Time.fixedDeltaTime;

		if (transform.position.x <= xMin
		    || transform.position.x >= xMax) {
			switch (borderBehavior) {
			case BorderBehavior.None:
				break;
			case BorderBehavior.Bounce:
				speed.x *= -1;
				break;
			case BorderBehavior.Stop:
				speed.x *= 0;
				break;
			}
		}
		transform.position = new Vector2(
			Mathf.Clamp(transform.position.x,
		            xMin + Mathf.Abs (speed.x) * speedMultiplier * Time.deltaTime,
		            xMax - Mathf.Abs (speed.x) * speedMultiplier * Time.deltaTime),
			transform.position.y);

		// enemy has reached bottom?
		if (transform.position.y <= LevelManager.Instance.levelBounds.yMin) {
			BroadcastMessage("OnReachedBottom", SendMessageOptions.DontRequireReceiver);

			Debug.Log ("Reached bottom", this);
			Destroy(gameObject);
		}
	}

	
	
	public void BombDestroy() {
		DestroyImmediate(gameObject);
	}

	protected virtual void TouchPlayer() {
		LevelManager.Instance.player.ReduceHealth(collisionDamage);
		ParticleEffectsManager.Instance.PlayExplosionEffect(gameObject.transform.position);
		BroadcastMessage("OnHitPlayer", SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
}
