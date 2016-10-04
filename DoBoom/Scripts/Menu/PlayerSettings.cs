using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerSettings : DoBoom {

	public Texture player1Button;
	public Texture player2Button;
	public Texture MenuButton;
	protected static int playerSettingNumber;
	private GUIStyle currentStyle = null;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		/*GUI.Label (new Rect (20, 20, 100, 100), "Place Boom");
		GUI.Label (new Rect (Screen.width / 4, Screen.height / 8, 100, 100), "Up");
		GUI.Label (new Rect (Screen.width / 4, Screen.height / 2, 100, 100), "Down");
		GUI.Label (new Rect (Screen.width / 8, Screen.height / 16 * 5, 100, 100), "Left");
		GUI.Label (new Rect (Screen.width / 8 * 3, Screen.height / 16 * 5, 100, 100), "Right");

		GUI.SetNextControlName ("Up");
		Up = GUI.TextField (new Rect (Screen.width / 4, Screen.height / 8, 20, 20), Up);
		GUI.SetNextControlName ("Down");
		Down = GUI.TextField (new Rect (Screen.width / 4, Screen.height / 2, 20, 20), Down);
		GUI.SetNextControlName ("Left");
		Left = GUI.TextField (new Rect (Screen.width / 8, Screen.height / 16 * 5, 20, 20), Left);
		GUI.SetNextControlName ("Right");
		Right = GUI.TextField (new Rect (Screen.width / 8 * 3, Screen.height / 16 * 5, 20, 20), Right);

		Debug.Log (Event.current.keyCode.ToString ());

		if (GUI.GetNameOfFocusedControl() == "Up") {
			Up = GUI.TextField (new Rect (Screen.width / 4, Screen.height / 8, 20, 20), KeyRefine(Up));
		}
		if (GUI.GetNameOfFocusedControl() == "Down") {
			Down = GUI.TextField (new Rect (Screen.width / 4, Screen.height / 2, 20, 20), KeyRefine(Down));
		}
		if (GUI.GetNameOfFocusedControl() == "Left") {
			Left = GUI.TextField (new Rect (Screen.width / 8, Screen.height / 16 * 5, 20, 20), KeyRefine(Left));
		}
		if (GUI.GetNameOfFocusedControl() == "Right") {
			Right = GUI.TextField (new Rect (Screen.width / 8 * 3, Screen.height / 16 * 5, 20, 20), KeyRefine(Right));
		}
		if (GUI.Button(new Rect (Screen.width / 8,
								Screen.height / 2 + Screen.height / 4,
								Screen.width / 4,
								Screen.height / 8),
						"Update")) {
			if (checkButton (Up, Down, Left, Right)) {
				playersControl [0].Up = Up;
				playersControl [0].Down = Down;
				playersControl [0].Left = Left;
				playersControl [0].Right = Right;
				flag = 1;
			} else {
				flag = 2;
			}
		}
		if (flag == 1) {
			GUI.TextArea (new Rect (Screen.width / 2, Screen.height / 2, 200, 50), "Updated!");
		} else if (flag == 2) {
			GUI.TextArea(new Rect (Screen.width / 2, Screen.height / 2, 200, 50), "You cannot set two buttons as the same key!");
		}
		if (GUI.Button(new Rect (Screen.width / 8 + Screen.width / 2,
								Screen.height / 2 + Screen.height / 4,
								Screen.width / 4,
								Screen.height / 8),
						"Menu")) {
			//Application.LoadLevel ("Menu");
			SceneManager.LoadScene("Menu");
		}*/
		Font myFont = (Font)Resources.Load("Fonts/Old School Toons", typeof(Font));
		Texture2D myTexture = (Texture2D)Resources.Load("Textures/background1", typeof(Texture2D));
		currentStyle = new GUIStyle (GUI.skin.box);
		currentStyle.normal.background = myTexture;
		currentStyle.font = myFont;
		currentStyle.fontSize = 30;
		currentStyle.alignment = TextAnchor.MiddleCenter;
		GUI.color = Color.cyan;
		GUI.contentColor = Color.black;

		if (GUI.Button (new Rect(Screen.width / 3, Screen.height / 4, Screen.width / 3, Screen.height / 6), "Player 1", currentStyle)) {
			playerSettingNumber = 0;
			SceneManager.LoadScene ("Player1");
		}
		if (GUI.Button (new Rect(Screen.width / 3, Screen.height / 2, Screen.width / 3, Screen.height / 6), "Player 2", currentStyle)) {
			playerSettingNumber = 1;
			SceneManager.LoadScene ("Player2");
		}
		if (GUI.Button (new Rect (Screen.width / 12, Screen.height / 12, Screen.width / 6, Screen.height / 8), "Menu", currentStyle)) {
			SceneManager.LoadScene ("Menu");
		}
	}
}
