using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PowerUp))]
public class Healing : MonoBehaviour {
	public float amount = 25;

	void OnPowerUp() {
		LevelManager.Instance.player.AddHealth(amount);
	}
}
