using UnityEngine;
using System.Collections;

public class KillCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void ChangeHUDElement () {
		gameObject.GetComponent<GUIText>().text = LevelManager.Instance.player.killCount.ToString();
		}

	// Update is called once per frame
	void Update () {
	
	}
}
