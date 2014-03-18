using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	void OnGUI() {
		const int buttonWidth = 120;
		const int buttonHeight = 60;

		var retryRect = new Rect(Screen.width / 2 - (buttonWidth / 2), (1 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight);
		if (GUI.Button (retryRect, "Retry!")) {
			Application.LoadLevel("Level1");
		}

		var backRect = new Rect (Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight);
		if (GUI.Button (backRect, "Back to menu")) {
			Application.LoadLevel("Menu");
		}

	}
}
