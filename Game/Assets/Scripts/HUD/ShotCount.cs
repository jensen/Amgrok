using UnityEngine;
using System.Collections;

public class ShotCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void ChangeHUDElement () {
		gameObject.GetComponent<GUIText>().text = LevelManager.Instance.player.shotNumber.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
