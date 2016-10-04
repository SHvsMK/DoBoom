using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UserInstructon : MonoBehaviour {

	private GUIStyle currentStyle = null;
	private GUIStyle currentStyle1 = null;
	private GUIStyle textStyle = null;
	public Texture2D[] img;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		int x1 = 100;
		int y1 = 120;

		Font myFont = (Font)Resources.Load("Fonts/Old School Toons", typeof(Font));
		Texture2D myTexture = (Texture2D)Resources.Load("Textures/board", typeof(Texture2D));
		Texture2D myTexture1 = (Texture2D)Resources.Load("Textures/background1", typeof(Texture2D));
		currentStyle = new GUIStyle (GUI.skin.box);
		currentStyle.normal.background = myTexture;
		currentStyle.font = myFont;
		currentStyle.fontSize = 50;
		currentStyle.normal.textColor = Color.white;
//		currentStyle.alignment = TextAnchor.MiddleCenter;
		textStyle = new GUIStyle ();
//		textStyle.normal.background = myTexture;
		textStyle.font = myFont;
		textStyle.fontSize = 30;
		textStyle.normal.textColor = Color.white;
		textStyle.alignment = TextAnchor.MiddleLeft;
//		textStyle.alignment = TextAnchor.MiddleCenter;
		currentStyle1 = new GUIStyle (GUI.skin.box);
		//			currentStyle.normal.background = MakeTex (100, 100, new Color (0.5f, 1f, 1f, 0.9f)); 
		//		currentStyle.normal.background = ;
		currentStyle1.normal.background = myTexture;
		currentStyle1.font = myFont;
		currentStyle1.fontSize = 50;
		currentStyle1.alignment = TextAnchor.MiddleCenter;
//		currentStyle.normal.textColor = Color.black;
//		GUI.color = Color.cyan;
//		GUI.contentColor = Color.black;

		GUI.Box (new Rect (x1, y1-40, Screen.width * 0.8f, Screen.height * 0.8f), "User Instruction", currentStyle);
		GUI.Label (new Rect (x1 + Screen.width * 0.1f , y1 + 80, Screen.width * 0.8f, Screen.height * 0.1f), "Your goal is to destroy the other's base ", textStyle);
		GUI.Label (new Rect (x1 + Screen.width * 0.58f, y1 + 80, Screen.width * 0.8f, Screen.height * 0.1f), new GUIContent ("!", img [0]), textStyle);
		GUI.Label (new Rect (x1 + Screen.width * 0.1f, y1 + 150, Screen.width * 0.8f, Screen.height * 0.1f), "You should collect stars ", textStyle);
		GUI.Label (new Rect (x1 + Screen.width * 0.40f, y1 + 150, Screen.width * 0.8f, Screen.height * 0.1f), new GUIContent("to produce special ", img[1]), textStyle);
		GUI.Label (new Rect (x1 + Screen.width * 0.06f, y1 + 200, Screen.width * 0.8f, Screen.height * 0.1f), "props which make you powerful!", textStyle);
		GUI.Label (new Rect (x1 + Screen.width * 0.1f, y1 + 270, Screen.width * 0.8f, Screen.height * 0.1f), "In only two cases you are unbeatable: ", textStyle);
		GUI.Label (new Rect (x1 + Screen.width * 0.15f, y1 + 320, Screen.width * 0.8f, Screen.height * 0.1f), "player revival and base being attacked", textStyle);
		GUI.Label (new Rect (x1 + Screen.width * 0.1f, y1 + 390, Screen.width * 0.8f, Screen.height * 0.1f), "Trigger is your the last straw, be careful to use!", textStyle);
		if (GUI.Button (new Rect (Screen.width / 12, Screen.height / 12, Screen.width / 6, Screen.height / 8), "Menu", currentStyle1)) {
			SceneManager.LoadScene ("Menu");
		}





		//		GUI.Label (new Rect (x1 + 110, y1 + 40, width, height), new GUIContent(" : " + StarNumber [0].ToString () , img[1]), textStyle3);
//		GUI.Label (new Rect (x1 + 20, y1 + 80, width, height), new GUIContent(" : " + StarNumber [0].ToString () , img[2]), textStyle3);
//		GUI.Label (new Rect (x1 + 110, y1 + 80, width, height), new GUIContent(" : " + StarNumber [0].ToString () , img[10]), textStyle3);
//		GUI.Label (new Rect (x1 + 40, y1 + 110, width, height), "Triger: " + trigerNumber [0].ToString () , textStyle3);

	}
}
