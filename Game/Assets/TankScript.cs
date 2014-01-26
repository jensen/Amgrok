using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class TankScript : MonoBehaviour {
		private Enemy _enemy;
		
		public float speed = 0.5F;
		public float healAmount = 15F;
		void Start() {
			_enemy = GetComponent<Enemy>();
			_enemy.speed = new Vector3 (0F, -speed, 0F);
		}

		void OnDestroyed() {
		if (LevelManager.Instance.player != null) { 
			LevelManager.Instance.player.AddHealth(healAmount);
		}
	}

		// Update is called once per frame
		void Update () {
		}
	}

