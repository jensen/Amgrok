using UnityEngine;
using System.Collections;

public class CrazyFireIndicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void ChangeHUDElement () {
		if (LevelManager.Instance.player.crazyFire) {
						gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
				} else {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
				}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
