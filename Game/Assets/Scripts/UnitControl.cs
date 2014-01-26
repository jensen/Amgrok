using UnityEngine;
using System.Collections;

public class UnitControl : MonoBehaviour {

	// Use this for initialization
	public Sprite A;
	public Sprite B;
	public Sprite C;
	public Sprite D;
	public Sprite E;

	void Start () {
	
	}

	public void getSprite(char sp) {
		SpriteRenderer sr = GetComponent ("SpriteRenderer") as SpriteRenderer;
		switch (sp) {
		case 'A':
			sr.sprite = A;
			break;
		case 'B':
			sr.sprite = B;
			break;
		case 'C':
			sr.sprite = C;
			break;
		case 'D':
			sr.sprite = D;
			break;
		default:
			sr.sprite = E;
			break;
				}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
