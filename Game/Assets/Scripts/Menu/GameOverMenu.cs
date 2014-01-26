﻿using UnityEngine;
using System.Collections;

public class GameOverMenu : Menu {

	void OnGUI() {
		GUI.skin = skin;

		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, screenCenter.y - buttonHeight, buttonWidth, buttonHeight), "Restart"))
		{
			Application.LoadLevel("Main");
		}
		
		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, screenCenter.y + buttonHeight, buttonWidth, buttonHeight), "Quit"))
		{
			Application.LoadLevel("Title");
		}
	}
}
