﻿using UnityEngine;

public class TitleMenu : Menu {

	/// <summary>
	/// Vertical pos of the menu relative to screen height. [0, 1]
	/// </summary>
	public float menuVertPos = 0.7f;

	public float bottomPadding = 0.1f;

	void OnGUI() {
		GUI.skin = skin;

		float margin = (Screen.width - buttonWidth) / 2;
		GUILayout.BeginArea(new Rect(margin, menuVertPos * Screen.height,
		                             Screen.width - 2 * margin, (1 - menuVertPos) * Screen.height));
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();

		if (GUILayout.Button("Easy")) Application.LoadLevel("Main");
		if (GUILayout.Button("Medium")) Application.LoadLevel("Main");
		if (GUILayout.Button("Hard")) Application.LoadLevel("Main");
		if (GUILayout.Button("Quit")) Application.Quit();

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.EndArea();

		/*
		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, Screen.height - ((buttonHeight + buttonPadding) * 3), buttonWidth, buttonHeight), "Play"))
		{
			Application.LoadLevel("Main");
		}
		
		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, Screen.height - ((buttonHeight + buttonPadding) * 2), buttonWidth, buttonHeight), "Quit"))
		{
			Application.Quit();
		}*/
	}
}
