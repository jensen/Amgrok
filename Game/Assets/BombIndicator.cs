using UnityEngine;
using System.Collections;

public class BombIndicator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void ChangeHUDElement () {
		gameObject.GetComponent<GUIText>().text = LevelManager.Instance.player.bomb.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
