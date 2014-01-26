using UnityEngine;
using System.Collections;

public class PlusDissapearer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void ChangeHUDElement () {
		if (LevelManager.Instance.player.bombPartsNeeded == 1 || LevelManager.Instance.player.bombParts == 0) {
			gameObject.GetComponent<GUIText>().text = "";
				} else {
						gameObject.GetComponent<GUIText> ().text = "+";
				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
