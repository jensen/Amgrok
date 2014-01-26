using UnityEngine;

public class TitleMenu : Menu {
	
	private float offsetFromCenter = 160;

	void OnGUI() {
		GUI.skin = skin;

		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, screenCenter.y + offsetFromCenter, buttonWidth, buttonHeight), "Play"))
		{
			Application.LoadLevel("Main");
		}

		if(GUI.Button (new Rect(screenCenter.x - buttonWidth/2, screenCenter.y + offsetFromCenter + (buttonHeight + buttonPadding), buttonWidth, buttonHeight), "Quit"))
		{
			Application.Quit();
		}
	}
}
