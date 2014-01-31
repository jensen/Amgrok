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

#if UNITY_ANDROID || UNITY_IPHONE
	
	public float Horizontal { get { return 0; } }
	public float Vertical { get { return 0; } }
	public bool Fire {
		get {
			return false;
		}
	}
	
	public bool Bomb {
		get {
			return false;
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
