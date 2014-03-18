using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	private GUISkin skin;

	void Start() {
		skin = Resources.Load ("BtnPlaySkin") as GUISkin;
	}

	void OnGUI() {
		const int buttonWidth = 84;
		const int buttonHeight = 60;

		GUI.skin = skin;

		if (GUI.Button (new Rect (Screen.width / 2 - (buttonWidth / 2),	(2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "Start!")) {
			//On Click, load the first level
			Application.LoadLevel ("Level1");
		}
	}
}
