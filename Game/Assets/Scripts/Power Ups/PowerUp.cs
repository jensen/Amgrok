using UnityEngine;
using System.Collections;

/// <summary>
/// Power ups inherit behavior of an enemy,  but power ups do not get
/// destroyed after getting show.
/// </summary>
public class PowerUp : Enemy {

	void Awake() {
		base.destroyOnShot = false;
	}

	void OnTouchPlayer() {
		BroadcastMessage("OnPowerUp", SendMessageOptions.DontRequireReceiver);
		SoundEffectsManager.Instance.PlayPowerupSound();
		Destroy(gameObject);
	}

	protected override void TouchPlayer () {
		Destroy(gameObject);
	}
}
