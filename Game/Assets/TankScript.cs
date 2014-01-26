using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class TankScript : MonoBehaviour {
		private Enemy _enemy;
		
		public float speed = 0.5F;
		
		void Start() {
			_enemy = GetComponent<Enemy>();
			_enemy.speed = new Vector3 (0F, -speed, 0F);
		}
		
		// Update is called once per frame
		void Update () {
		}
	}

