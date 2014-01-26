using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	protected GUISkin skin;
	
	protected float buttonWidth = 200;
	protected float buttonHeight = 40;
	protected float buttonPadding = 20;

	protected Vector2 screenCenter;
	
	void Start() {
		
		screenCenter = new Vector2(Screen.width/2, Screen.height/2);
		skin = Resources.Load ("GUISkin") as GUISkin;
	}
}
