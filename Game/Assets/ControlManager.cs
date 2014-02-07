using UnityEngine;
using System.Collections;

public class ControlManager : MonoBehaviour {
	#region Instance
	private static ControlManager _instance;

	public static ControlManager Instance {
		get {

			if (_instance == null) {

				var cm = GameObject.FindObjectOfType<ControlManager>();

				if (cm == null) {
					Debug.LogWarning("No ControlManager present. Creating.");
					var go = new GameObject();
					_instance = go.AddComponent<ControlManager>();
				} else {
					_instance = cm;
				}
			}

			return _instance;
		}
	}
	#endregion

	public float touchMoveGain = 2f;
	public bool bombing = false;

#if UNITY_ANDROID || UNITY_IPHONE
	public Vector2 command = Vector2.zero;

	void Update() {
		command = Vector2.zero;
		bombing = (Input.touchCount == 2);

		if (Input.touchCount > 0) {
			Vector2 center = new Vector2(Screen.width / 2f, Screen.height / 2f);
			//Vector2 center = Camera.main.WorldToScreenPoint(LevelManager.Instance.player.transform.position);

			var t = Input.GetTouch(0);
			command = (touchMoveGain * (center - t.position) / Screen.width).normalized;
		}
	}


	public float Horizontal { get { return -command.x; } }
	public float Vertical { get { return -command.y; } }
	public bool Fire {
		get {
			return true;
		}
	}
	
	public bool Bomb {
		get {
			return bombing;
		}
	}

#else

	public float Horizontal { get { return Input.GetAxis("Horizontal"); } }
	public float Vertical { get { return Input.GetAxis("Vertical"); } }
	public bool Fire {
		get {
			return Input.GetKey (KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl) || 
				Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.Z);
		}
	}

	public bool Bomb {
		get {
			return Input.GetKey (KeyCode.X) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift);
		}
	}

#endif

}
