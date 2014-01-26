using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	// Use this for initialization
	public Sprite[] instructions = new Sprite[4];
	public int page = 0;
	void Start () {
	
	}

	public void Forward () {
		if (page < instructions.Length - 1) {
						page ++;
			gameObject.GetComponent<SpriteRenderer>().sprite = instructions[page];
				}
	}
	
	public void Back () {
		if (page > 0) {
			page --;
			gameObject.GetComponent<SpriteRenderer>().sprite = instructions[page];
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
