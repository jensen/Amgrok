using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class InitializationScript : MonoBehaviour {
	
	public const int numSprites = 15;
	public const int numEnemies = 5;
	public Sprite[] spriteSet = new Sprite[numSprites];
	public GameObject[] units = new GameObject[numEnemies];
	// Use this for initialization
	void Start () {
		
		spriteSet = spriteSet.OrderBy(c => System.Guid.NewGuid()).ToArray();
		for (int i = 0; i < numEnemies; i ++) {
			units[i].GetComponent<SpriteRenderer>().sprite = spriteSet[i];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
