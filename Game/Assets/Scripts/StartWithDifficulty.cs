using UnityEngine;
using System.Collections;

public class StartWithDifficulty : MonoBehaviour {

	public int difficulty = 0;

	IEnumerator Start () {
		yield return new WaitForSeconds(.1f);
		LevelManager.Instance.ChangeDifficulty(difficulty);
		Destroy(gameObject);
	}
}
