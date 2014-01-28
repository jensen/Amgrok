using UnityEngine;
using System.Collections;

public class KillCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void ChangeHUDElement () {
		if (LevelManager.Instance.endless) {
			gameObject.GetComponent<GUIText> ().text = LevelManager.Instance.player.killCount.ToString ();
		} else {
			gameObject.GetComponent<GUIText> ().text = "";
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
