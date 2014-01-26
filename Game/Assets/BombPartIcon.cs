using UnityEngine;
using System.Collections;

public class BombPartIcon : MonoBehaviour {

	// Use this for initialization
	public Sprite emptyBomb;
	public Sprite quarterBomb;
	public Sprite halfBomb;
	public Sprite threeQuarterBomb;

	void Start () {
	
	}

	void ChangeHUDElement () {
		if (LevelManager.Instance.player.bombPartsNeeded == 1 || LevelManager.Instance.player.bombParts == 0) {
			gameObject.GetComponent<SpriteRenderer>().sprite = emptyBomb;
		} else if  (LevelManager.Instance.player.bombPartsNeeded == 4 || LevelManager.Instance.player.bombParts == 1) {
			gameObject.GetComponent<SpriteRenderer>().sprite = quarterBomb;

		} else if  (LevelManager.Instance.player.bombPartsNeeded == 4 || LevelManager.Instance.player.bombParts == 3) {
			gameObject.GetComponent<SpriteRenderer>().sprite = threeQuarterBomb;
			
		} else {
			gameObject.GetComponent<SpriteRenderer>().sprite = halfBomb;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
