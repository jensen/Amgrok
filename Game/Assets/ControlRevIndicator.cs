using UnityEngine;
using System.Collections;

public class ControlRevIndicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void ChangeHUDElement () {
		if (LevelManager.Instance.player.horizSpeed < 0) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
