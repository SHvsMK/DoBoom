using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : DoBoom {

	public Texture2D notextTrue;
	public Texture DoBoomSign;
	public Texture playerSettingButton;
	private GUIStyle currentStyle = null;
	private GUIStyle titleStyle = null;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		
		Font myFont = (Font)Resources.Load("Fonts/Old School Toons", typeof(Font));
		Texture2D myTexture = (Texture2D)Resources.Load("Textures/background1", typeof(Texture2D));
		currentStyle = new GUIStyle (GUI.skin.box);
		//			currentStyle.normal.background = MakeTex (100, 100, new Color (0.5f, 1f, 1f, 0.9f)); 
//		currentStyle.normal.background = ;
		currentStyle.normal.background = myTexture;
		currentStyle.font = myFont;
		currentStyle.fontSize = 50;
		currentStyle.alignment = TextAnchor.MiddleCenter;
		GUI.color = Color.cyan;
		GUI.contentColor = Color.black;

		titleStyle = new GUIStyle ();
		titleStyle.font = myFont;
		titleStyle.fontSize = 70;
		titleStyle.normal.background = notextTrue;
		titleStyle.alignment = TextAnchor.MiddleCenter;
//		GUI.contentColor = Color.black;

		GUI.Label (new Rect (Screen.width / 4, Screen.height / 11, Screen.width / 2 , Screen.height / 4 ), "Doboom " , titleStyle);
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 3.5f, Screen.width / 3, Screen.height / 8), "Start", currentStyle)) {
			SceneManager.LoadScene ("GamePlay");
		}
		if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 2.15f + 15, Screen.width / 3, Screen.height / 8), "Player Settings", currentStyle)) {
			SceneManager.LoadScene ("Player Settings");
		}
		if (GUI.Button (new Rect (Screen.width / 3, Screen.height / 1.5f, Screen.width / 3, Screen.height / 8), "User instruction", currentStyle))
			SceneManager.LoadScene ("User Instruction");
		
	}
}
