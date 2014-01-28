using UnityEngine;
using System.Collections;

public class LevelCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void ChangeHUDElement () {
		gameObject.GetComponent<GUIText> ().text = LevelManager.Instance.level.ToString();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
