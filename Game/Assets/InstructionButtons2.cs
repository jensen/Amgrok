using UnityEngine;

public class InstructionButtons2 : Menu {
	
	/// <summary>
	/// Vertical pos of the menu relative to screen height. [0, 1]
	/// </summary>
	public float menuVertPos = 0.7f;
	public Instructions ins;
	public Rect rect = new Rect (.05f, .15f, .05f, .95f);
	
	public float bottomPadding = 0.05f;
	
	void OnGUI() {
		
		//rect = new Rect (rect.x * Screen.width, rect.y * Screen.height, rect.width * Screen.width, rect.height * Screen.height);
		
		//GUI.skin = skin;
		//GUILayout.BeginArea(rect);
		//GUILayout.BeginHorizontal();
		//GUILayout.FlexibleSpace();
		GUILayout.BeginHorizontal("box");
		if(GUILayout.Button("Back")) ins.Back ();
		if (GUILayout.Button("Main Menu")) Application.LoadLevel("Title");
		if(GUILayout.Button("Forward")) ins.Forward ();
		GUILayout.EndHorizontal();
		//}
		
		//GUILayout.EndHorizontal();
		//GUILayout.EndArea();
		
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
	
	void LoadWithDifficulty(int d) {
		GameObject go = new GameObject("LoadWithDifficulty");
		DontDestroyOnLoad(go);
		var c = go.AddComponent<StartWithDifficulty>();
		c.difficulty = d;
		Application.LoadLevel("Main");
	}
}
