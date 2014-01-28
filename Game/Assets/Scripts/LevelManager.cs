using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton class for LevelManager.
/// Use it like:
/// <code>
/// LevelManager.Instance.player
/// LevelManager.Instance.spawning
/// LevelManager.Instance.levelBounds
/// </code>
/// </summary>
public class LevelManager : MonoBehaviour {
	//are we in endless mode?
	public bool endless;

	public Player player;
	public Spawning spawning;
	public Shooter shooter;
	/// Boundaries of the level
	public Rect levelBounds;
	public int difficulty;
	public InGameHUDScript hud;

	private static bool _onDestroy = false;
	private static LevelManager _instance;

	/// <summary>
	/// Gets the instance of LevelManager, create the LevelManager if needed.
	/// </summary>
	/// <value>The instance.</value>
	public static LevelManager Instance {
		get {
			if (_instance == null) {

				if (_onDestroy) {
					Debug.Log("Application is quitting, don't create a new LevelManager. (return null)");
					return null;
				}

				// Find a LevelManager
				LevelManager[] lms = GameObject.FindObjectsOfType<LevelManager>();

				if (lms.Length == 0) {
					// instantiate a new singleton
					Debug.LogWarning("There is no LevelManager, creating.");
					var go = new GameObject("Level Manager");
					_instance = go.AddComponent<LevelManager>();
				} else {
					if (lms.Length > 1) Debug.LogWarning("There are two or more instances of LevelManager.");
					_instance = lms[0];
				}
			}

			return _instance;
		}
	}

	public void EndlessUpgrade() {
		player.damageMult = player.damageMultEndlessIncrement;
		shooter.maxShotDelay *= shooter.maxShotDelayEndlessIncrement;
		shooter.minShotDelay *= shooter.minShotDelayEndlessIncrement;
		Enemy.speedMultiplier += Enemy.speedMultiplierEndlessIncrement;
		spawning.spawnRateMin *= spawning.spawnRateMinEndlessIncrement;
		spawning.spawnRateMax *= spawning.spawnRateMaxEndlessIncrement;
		}

	public void ChangeDifficulty(int difficulty) { //Takes 1=easy, 2=med,3=hard, 0=endless (not implemented)
			if (player != null) {
			this.difficulty = difficulty;
			if (difficulty == 0) {
				endless = true;
				player.damageMult = player.damageMultEndless;
				player.bombPartsNeeded = player.bombPartsNeededEndless;
				shooter.maxShotDelay = shooter.maxShotDelayEndless;
				shooter.minShotDelay = shooter.minShotDelayEndless;
				Enemy.speedMultiplier = Enemy.speedMultiplierEndless;
				spawning.spawnRateMin = spawning.spawnRateMinEndless;
				spawning.spawnRateMax = spawning.spawnRateMaxEndless;
			}else if (difficulty == 1) {
				player.damageMult = player.damageMultEasy;
				player.bombPartsNeeded = player.bombPartsNeededEasy;
				shooter.maxShotDelay = shooter.maxShotDelayEasy;
				shooter.minShotDelay = shooter.minShotDelayEasy;
				Enemy.speedMultiplier = Enemy.speedMultiplierEasy;
				spawning.spawnRateMin = spawning.spawnRateMinEasy;
				spawning.spawnRateMax = spawning.spawnRateMaxEasy;
			} else if (difficulty == 2) {
				player.damageMult = player.damageMultMed;
				player.bombPartsNeeded = player.bombPartsNeededMed;
				shooter.maxShotDelay = shooter.maxShotDelayMed;
				shooter.minShotDelay = shooter.minShotDelayMed;
				Enemy.speedMultiplier = Enemy.speedMultiplierMed;
				spawning.spawnRateMin = spawning.spawnRateMinMed;
				spawning.spawnRateMax = spawning.spawnRateMaxMed;
			} else {
				player.damageMult = player.damageMultHard;
				player.bombPartsNeeded = player.bombPartsNeededHard;
				shooter.maxShotDelay = shooter.maxShotDelayHard;
				shooter.minShotDelay = shooter.minShotDelayHard;
				Enemy.speedMultiplier = Enemy.speedMultiplierHard;
				spawning.spawnRateMin = spawning.spawnRateMinHard;
				spawning.spawnRateMax = spawning.spawnRateMaxHard;
			}
				}
		}

	static T FindOrWarn<T>() where T : Object {
		string name = typeof(T).Name;
		var ts = GameObject.FindObjectsOfType<T>();
		if (ts.Length > 1) Debug.LogWarning("There are more than two " + name + ".");
		if (ts.Length == 0) {
			Debug.LogError("There is no " + name + ".");
			return null;
		}

		return ts[0];
	}

	void Awake() {
		_onDestroy = false;

		player = FindOrWarn<Player>();
		spawning = FindOrWarn<Spawning>();
	}

	void OnDestroy() {
		_onDestroy = true;
	}

	void OnDrawGizmos() {
		Gizmos1.DrawRect(levelBounds, new Color(.9f, .95f, 1f, .3f), .1f);
	}
}
