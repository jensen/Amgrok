using UnityEngine;
using System.Collections;

public class DissapearOnNonEndless : MonoBehaviour {

	// Use this for initialization
	public string text;
	void Start () {
	
	}
	void ChangeHUDElement () {
		if (LevelManager.Instance.endless) {
			gameObject.GetComponent<GUIText> ().text = text;
		} else {
			gameObject.GetComponent<GUIText> ().text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
