using UnityEngine;
using System.Collections;

public class SoundEffectsManager : MonoBehaviour {
	
	public static SoundEffectsManager Instance;

	public AudioClip powerupSound;
	public AudioClip deathSound;
	public AudioClip shootSound;
	public AudioClip hitSound;
	
	public void Awake() {
		Instance = this;
	}

	public void PlayPowerupSound() {
		PlaySound(powerupSound);
	}

	public void PlayDeathSound() {
		PlaySound(deathSound);
	}

	public void PlayShootSound() {
		PlaySound(shootSound);
	}

	public void PlayHitSound() {
		PlaySound(hitSound);
	}

	private void PlaySound(AudioClip sound) {
		AudioSource.PlayClipAtPoint(sound, Vector3.zero);
	}

}
