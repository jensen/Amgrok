using UnityEngine;
using System.Collections;

public class GameOverMenu : Menu {

	void OnGUI() {
		GUI.skin = skin;

		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, Screen.height - ((buttonHeight + buttonPadding) * 3), buttonWidth, buttonHeight), "Restart"))
		{
			LoadWithDifficulty(LevelManager.Instance.difficulty);
		}
		
		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, Screen.height - ((buttonHeight + buttonPadding) * 2), buttonWidth, buttonHeight), "Main Menu"))
		{
			Application.LoadLevel("Title");
		}
		
		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, Screen.height - ((buttonHeight + buttonPadding) * 1), buttonWidth, buttonHeight), "Quit"))
		{
			Application.Quit();
		}
	}
			
	void LoadWithDifficulty(int d) {
		GameObject go = new GameObject("LoadWithDifficulty");
		DontDestroyOnLoad(go);
		var c = go.AddComponent<StartWithDifficulty>();
		c.difficulty = d;
		Application.LoadLevel("Main");
	}
}
