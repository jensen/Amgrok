using UnityEngine;

public class ParticleEffectsManager : MonoBehaviour {

	public static ParticleEffectsManager Instance;

	public ParticleSystem explosion;
	public ParticleSystem bomb;

	void Awake() {
		Instance = this;
	}

	public void PlayExplosionEffect(Vector3 position) {
		PlayEffect(explosion, position);
	}
	
	public void PlayBombEffect(Vector3 position) {
		PlayEffect(bomb, position);
	}

	private ParticleSystem PlayEffect(ParticleSystem effect, Vector3 position)
	{
		ParticleSystem ps = Instantiate(effect, position, Quaternion.identity) as ParticleSystem;

		DestroyObject(ps.gameObject, ps.startLifetime);

		return ps;
	}
}
