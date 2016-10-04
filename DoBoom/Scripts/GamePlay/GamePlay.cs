using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlay : DoBoom {
	private GUIStyle currentStyle = null;
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {
		Font myFont = (Font)Resources.Load("Fonts/Old School Toons", typeof(Font));
		currentStyle = new GUIStyle ();
		currentStyle.font = myFont;
		currentStyle.fontSize = 100;
		currentStyle.normal.textColor = Color.red;
		currentStyle.fontStyle = FontStyle.Bold;
		if (GameOver) {
			GUI.Box (new Rect (Screen.width / 3, Screen.height / 2.5f, Screen.width / 3, Screen.height / 3), "Game Over", currentStyle);
		}
	}
}
