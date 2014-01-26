using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	/// Scrolling magnitude and direction
	public Vector2 scroll = new Vector2(0, 0.2f);


	private Vector2 _offset;

	void OnEnable() {
		_offset = Vector2.zero;
	}

	void Update () {
		renderer.material.mainTextureOffset = (_offset += scroll * Time.deltaTime);
	}
}
