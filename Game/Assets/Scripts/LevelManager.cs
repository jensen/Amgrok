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
	public Player player;
	public Spawning spawning;

	/// Boundaries of the level
	public Rect levelBounds;

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
