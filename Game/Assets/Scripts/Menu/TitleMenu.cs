using UnityEngine;

public class TitleMenu : Menu {

	void OnGUI() {
		GUI.skin = skin;

		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, screenCenter.y, buttonWidth, buttonHeight), "Play"))
		{
			Application.LoadLevel("Main");
		}

		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, screenCenter.y + buttonHeight + buttonPadding, buttonWidth, buttonHeight), "Quit"))
		{
			Application.Quit();
		}
	}
}
