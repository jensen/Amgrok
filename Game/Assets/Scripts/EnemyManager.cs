using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	// Use this for initialization
	public static int numSprites = 5;
	public char[] charCodes = new char[5]{'A','B','C','D','E'};
	public UnitControl[] unitCont = new UnitControl[numSprites];
	public GameObject[] units = new GameObject[numSprites];
	public float gameTime = 0;
	public int lowSpawnTime = 1;
	public int highSpawnTime = 5;
	public int nextSpawnTime = 5;
	public Rect spawnZone = new Rect(-10, -10, 10, 10);
	void Start () {
		
		for (int i = 0; i < charCodes.Length - 1; i += 1)
		{
			int swapIndex = Random.Range(i, charCodes.Length);
			if (swapIndex != i) {
				char temp = charCodes[i];
				charCodes[i] = charCodes[swapIndex];
				charCodes[swapIndex] = temp;
			}
		}
		for (int i = 0; i < numSprites; i += 1) {
			unitCont[i].getSprite(charCodes[i]);
		}
	}

	Vector2 GetSpawnPosition() {
		return new Vector3(Random.Range(spawnZone.xMin, spawnZone.xMax),
		                   Random.Range(spawnZone.yMin, spawnZone.yMax),0);
	}

	// Update is called once per frame
	void Update () {
		gameTime += Time.deltaTime;
		if (gameTime > nextSpawnTime) {
			nextSpawnTime += Random.Range (lowSpawnTime,highSpawnTime);
			Instantiate (units[Random.Range (0,numSprites-1)], GetSpawnPosition(), Quaternion.identity); 

				}
	}

	void OnDrawGizmos() {
		Gizmos1.DrawRect(spawnZone, new Color(1, .5f, .3f, .4f));
		}
}
