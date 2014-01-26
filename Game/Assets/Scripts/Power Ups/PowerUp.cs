using UnityEngine;
using System.Collections;

/// <summary>
/// Power ups inherit behavior of an enemy,  but power ups do not get
/// destroyed after getting show.
/// </summary>
public class PowerUp : Enemy {
	public float amount = 25;

	void Awake() {
		base.destroyOnShot = false;
	}

	void OnTouchPlayer() {
		SoundEffectsManager.Instance.PlayPowerupSound();
		LevelManager.Instance.player.AddHealth(amount);
		Destroy(gameObject);
	}
}
