using UnityEngine;
using System.Collections;

public class RotationIndicator : MonoBehaviour {

	public Sprite noRotate;
	public Sprite rightRotate;
	public Sprite fullRotate;
	public Sprite leftRotate;

	// Use this for initialization
	void Start () {
	
	}

	void ChangeHUDElement () {
		int rotState = LevelManager.Instance.player.shootingDirection;
		if (rotState == 0) {
						gameObject.GetComponent<SpriteRenderer> ().sprite = noRotate;
				} else if (rotState == 1) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = leftRotate;
		} else if (rotState == 2) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = fullRotate;
		} else if (rotState == 3) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = rightRotate;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
