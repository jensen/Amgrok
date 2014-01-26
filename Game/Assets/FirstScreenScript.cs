using UnityEngine;
using System.Collections;

public class FirstScreenScript : MonoBehaviour {

	public float timeToSwitch = 1F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeToSwitch -= Time.deltaTime;
		if (timeToSwitch <= 0) {
			Application.LoadLevel("Title");
				}
	}
}
