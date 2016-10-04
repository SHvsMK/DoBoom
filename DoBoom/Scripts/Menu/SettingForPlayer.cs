using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SettingForPlayer : PlayerSettings {

	private string Up, Down, Left, Right, placeButton, Triger;
	private string[] createButton;
	private int flag;
	private GUIStyle currentStyle = null;
	private GUIStyle titleStyle = null;
	private GUIStyle textAreaStyle = null;
	// Use this for initialization
	void Start () {
		Up = playersControl [playerSettingNumber].Up;
		Down = playersControl [playerSettingNumber].Down;
		Left = playersControl [playerSettingNumber].Left;
		Right = playersControl [playerSettingNumber].Right;
		placeButton = playersControl [playerSettingNumber].place;
		Triger = playersControl [playerSettingNumber].triger;
		createButton = new string[6];
		for (var i = 0; i < 6; i++) {
			createButton [i] = playersControl [playerSettingNumber].createObject [i];
		}
		flag = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	private string KeyRefine(string oldkey) {
		var newkey = Event.current.keyCode.ToString ();
		if (newkey == "None")
			return oldkey;
		return newkey;
	}

	private bool checkButton(string up, string down, string left, string right, string place, string[] create, string triger) {
		Dictionary<string, int> ButtonNote;
		ButtonNote = new Dictionary<string, int> ();
		ButtonNote [up] = 1;
		if (ButtonNote.ContainsKey (down))
			return false;
		else
			ButtonNote [down] = 1;
		if (ButtonNote.ContainsKey (left))
			return false;
		else
			ButtonNote [left] = 1;
		if (ButtonNote.ContainsKey (right))
			return false;
		else
			ButtonNote [right] = 1;
		if (ButtonNote.ContainsKey (place))
			return false;
		else
			ButtonNote [place] = 1;
		if (ButtonNote.ContainsKey (triger))
			return false;
		else
			ButtonNote [triger] = 1;
		for (var i = 0; i < 6; i++) {
			if (ButtonNote.ContainsKey (create[i]))
				return false;
			else
				ButtonNote [create[i]] = 1;
		}
		return true;
	}

	void OnGUI() {
		Font myFont = (Font)Resources.Load("Fonts/Old School Toons", typeof(Font));
		Texture2D myTexture = (Texture2D)Resources.Load("Textures/background1", typeof(Texture2D));
		Texture2D myTexture2 = (Texture2D)Resources.Load("Textures/balloon", typeof(Texture2D));
		currentStyle = new GUIStyle (GUI.skin.box);

		currentStyle.normal.background = myTexture;
		currentStyle.font = myFont;
		currentStyle.fontSize = 20;
		currentStyle.alignment = TextAnchor.MiddleCenter;
		GUI.color = Color.cyan;
		GUI.contentColor = Color.black;
		int h = 12;
		int w = 6;
		titleStyle = new GUIStyle ();
		titleStyle.font = myFont;
		titleStyle.fontSize = 20;
//		titleStyle.normal.background = notextTrue;
		titleStyle.alignment = TextAnchor.MiddleCenter;
		textAreaStyle = new GUIStyle (GUI.skin.box);
		textAreaStyle.normal.background = myTexture2;
		textAreaStyle.font = myFont;
		textAreaStyle.fontSize = 20;
		textAreaStyle.alignment = TextAnchor.MiddleCenter;
		GUI.Label (new Rect (Screen.width / 8, Screen.height / 8, Screen.width / 6, Screen.height / h), "Up", titleStyle);
		GUI.Label (new Rect (Screen.width / 8, Screen.height / 4, Screen.width / 6, Screen.height / h), "Down", titleStyle);
		GUI.Label (new Rect (Screen.width / 8, Screen.height / 8 * 3, Screen.width / 6, Screen.height / h), "Left", titleStyle);
		GUI.Label (new Rect (Screen.width / 8, Screen.height / 2, Screen.width / 6, Screen.height / h), "Right", titleStyle);
		GUI.Label (new Rect (Screen.width / 8, Screen.height / 8 * 5, Screen.width / 6, Screen.height / h), "Place", titleStyle);
		GUI.Label (new Rect (Screen.width / 8, Screen.height / 4 * 3, Screen.width / 6, Screen.height / h), "Triger", titleStyle);

		GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 8, Screen.width / 6, Screen.height / h), "Bomb", titleStyle);
		GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 4, Screen.width / 6, Screen.height / h), "Speed", titleStyle);
		GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 8 * 3, Screen.width / 6, Screen.height / h), "Range1", titleStyle);
		GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2, Screen.width / 6, Screen.height / h), "Range2", titleStyle);
		GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 8 * 5, Screen.width / 6, Screen.height / h), "Range3", titleStyle);
		GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 4 * 3, Screen.width / 6, Screen.height / h), "TickShoe", titleStyle);

		GUI.SetNextControlName ("Up");
		Up = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 8, Screen.width / w, Screen.height / h), Up, textAreaStyle);
		GUI.SetNextControlName ("Down");
		Down = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 4, Screen.width / w, Screen.height / h), Down, textAreaStyle);
		GUI.SetNextControlName ("Left");
		Left = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 8 * 3, Screen.width / w, Screen.height / h), Left, textAreaStyle);
		GUI.SetNextControlName ("Right");
		Right = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 2, Screen.width / w, Screen.height / h), Right, textAreaStyle);
		GUI.SetNextControlName ("Place");
		placeButton = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 8 * 5, Screen.width / w, Screen.height / h), placeButton, textAreaStyle);
		GUI.SetNextControlName ("Triger");
		Triger = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 4 * 3, Screen.width / w, Screen.height / h), Triger, textAreaStyle);

		GUI.SetNextControlName ("Bomb");
		createButton[0] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 8, Screen.width / w, Screen.height / h), createButton[0], textAreaStyle);
		GUI.SetNextControlName ("Speed");
		createButton[2] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 4, Screen.width / w, Screen.height / h), createButton[2], textAreaStyle);
		GUI.SetNextControlName ("Range1");
		createButton[1] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 8 * 3, Screen.width / w, Screen.height / h), createButton[1], textAreaStyle);
		GUI.SetNextControlName ("Range2");
		createButton[3] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 2, Screen.width / w, Screen.height / h), createButton[3], textAreaStyle);
		GUI.SetNextControlName ("Range3");
		createButton[4] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 8 * 5, Screen.width / w, Screen.height / h), createButton[4], textAreaStyle);
		GUI.SetNextControlName ("TickShoe");
		createButton[5] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 4 * 3, Screen.width / w, Screen.height / h), createButton[5], textAreaStyle);


		if (GUI.GetNameOfFocusedControl() == "Up") {
			Up = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 8, Screen.width / w, Screen.height / h), KeyRefine(Up), textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "Down") {
			Down = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 4, Screen.width / w, Screen.height / h), KeyRefine(Down), textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "Left") {
			Left = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 8 * 3, Screen.width / w, Screen.height / h), KeyRefine(Left),textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "Right") {
			Right = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 2, Screen.width / w, Screen.height / h), KeyRefine(Right), textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "Place") {
			placeButton = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 8 * 5, Screen.width / w, Screen.height / h), KeyRefine(placeButton), textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "Triger") {
			Triger = GUI.TextField (new Rect (Screen.width / 3 - Screen.width / 15, Screen.height / 4 * 3, Screen.width / w, Screen.height / h), KeyRefine(Triger), textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "Bomb") {
			createButton[0] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 8, Screen.width / w, Screen.height / h), KeyRefine(createButton[0]), textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "Speed") {
			createButton[2] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 4, Screen.width / w, Screen.height / h), KeyRefine(createButton[2]),textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "Range1") {
			createButton[1] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 8 * 3, Screen.width / w, Screen.height / h), KeyRefine(createButton[1]), textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "Range2") {
			createButton[3] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 2, Screen.width / w, Screen.height / h), KeyRefine(createButton[3]), textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "Range3") {
			createButton[4] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 8 * 5, Screen.width / w, Screen.height / h), KeyRefine(createButton[4]), textAreaStyle);
		}
		if (GUI.GetNameOfFocusedControl() == "TickShoe") {
			createButton[5] = GUI.TextField (new Rect (Screen.width / 3 * 2 - Screen.width / 15, Screen.height / 4 * 3, Screen.width / w, Screen.height / h), KeyRefine(createButton[5]), textAreaStyle);
		}

		if (GUI.Button(new Rect (Screen.width / 30 * 13,
								Screen.height / 8 * 7,
								Screen.width / 6,
								Screen.height / 12),
			"Update", currentStyle)) {
			if (checkButton (Up, Down, Left, Right, placeButton, createButton, Triger)) {
				playersControl [playerSettingNumber].Up = Up;
				playersControl [playerSettingNumber].Down = Down;
				playersControl [playerSettingNumber].Left = Left;
				playersControl [playerSettingNumber].Right = Right;
				playersControl [playerSettingNumber].place = placeButton;
				playersControl [playerSettingNumber].triger = Triger;
				playersControl [playerSettingNumber].createObject[0] = createButton[0];
				playersControl [playerSettingNumber].createObject[1] = createButton[1];
				playersControl [playerSettingNumber].createObject[2] = createButton[2];
				playersControl [playerSettingNumber].createObject[3] = createButton[3];
				playersControl [playerSettingNumber].createObject[4] = createButton[4];
				playersControl [playerSettingNumber].createObject[5] = createButton[5];
				flag = 1;
			} else {
				flag = 2;
			}
		}
		if (flag == 1) {
			GUI.TextArea (new Rect (Screen.width / 8 * 7, Screen.height / 24, Screen.width / 10, Screen.width / 20), "Updated!", textAreaStyle);
		} else if (flag == 2) {
			GUI.TextArea(new Rect (Screen.width / 8 * 7, Screen.height / 24, Screen.width / 10, Screen.width / 20), "You cannot set two buttons as the same key!",textAreaStyle);
		}
		if (GUI.Button (new Rect (Screen.width / 24, Screen.height / 24, Screen.width / 6, Screen.height / 12), "Player Settings", currentStyle)) {
			SceneManager.LoadScene ("Player Settings");
		}
	}
}
