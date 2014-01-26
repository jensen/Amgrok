using UnityEngine;

public static class Gizmos1 {	
	public static void DrawRect(Rect r, Color c, float fillOpacity=0.3f) {
		Gizmos.color = c;
		Gizmos.DrawWireCube(r.center, new Vector2(r.width, r.height));
		Gizmos.color = c * new Color(1, 1, 1, fillOpacity);
		Gizmos.DrawCube(r.center, new Vector2(r.width, r.height));
	}
}
