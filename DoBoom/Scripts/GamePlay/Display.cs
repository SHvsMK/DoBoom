using UnityEngine;
using System.Collections;

public class Display : DoBoom {

	private int[] trigerNumber;
	private int[] StarNumber;
	private int[] BombNumber;
	private int[] BombRange;
	private float[] SpeedOfPlayer;
	private int[] SpeicialShoe;
	private int[] baseHealth;
	private GUIStyle currentStyle = null;
	private GUIStyle currentStyle2 = null;
	private GUIStyle textStyle = null;
	private GUIStyle textStyle2 = null;
	private GUIStyle textStyle3 = null;
	private GUIStyle textStyle4 = null;
	public Texture[] img;
	// Use this for initialization
	void Start () {
		trigerNumber = new int[2];
		StarNumber = new int[2];
		BombNumber = new int[2];
		BombRange = new int[2];
		SpeedOfPlayer = new float[2];
		SpeicialShoe = new int[2];
		baseHealth = new int[2];
		for (var i = 0; i < 2; i++) {
			trigerNumber [i] = 0;
			StarNumber [i] = 0;
			BombNumber [i] = 0;
			BombRange [i] = 0;
			SpeedOfPlayer [i] = 0;
			SpeicialShoe [i] = 0;
			baseHealth [i] = 0;
		}
	}

	// Update is called once per frame
	void Update () {
		for (var i = 0; i < 2; i++) {
			trigerNumber [i] = trigerTime [i];
			if (playerLive [i]) {
				StarNumber [i] = playerList [i].GetComponent<PlayerAttribute> ().GetNumberOfStars ();
				BombNumber [i] = playerList [i].GetComponent<PlayerAttribute> ().GetNumberOfBombs ();
				BombRange [i] = playerList [i].GetComponent<PlayerAttribute> ().GetRangeOfBomb ();
				SpeedOfPlayer [i] = playerList [i].GetComponent<PlayerAttribute> ().GetSpeed ();
			} else {
				StarNumber [i] = 0;
				BombNumber [i] = 0;
				BombRange [i] = 0;
				SpeedOfPlayer [i] = 0;
			}
			if (baseLive [i]) {
				baseHealth [i] = Bases [i].GetComponent<BaseAttribute> ().GetBaseHealth ();
			}
		}
	}

	void OnGUI () {
		int  x1 = 0, y1 = 0, x2 = 1220, y2 = 0;
		int x3 = 20, y3 = 30;
		int width = 150, height = 30;
		//		Color[] colors = new Color[]{ Color.white };
		Font myFont = (Font)Resources.Load("Fonts/Old School Toons", typeof(Font));
		Texture2D myTexture = (Texture2D)Resources.Load("Textures/canvas", typeof(Texture2D));
		Texture2D woodTexture = (Texture2D)Resources.Load("Textures/woodpan", typeof(Texture2D));
		if (currentStyle == null) {
			currentStyle = new GUIStyle (GUI.skin.box);
			//			currentStyle.normal.background = MakeTex (100, 100, new Color (0.5f, 1f, 1f, 0.9f)); 
			currentStyle.normal.background = myTexture;
			currentStyle.font = myFont;
			currentStyle.fontSize = 35;
			currentStyle.normal.textColor = Color.black;
			currentStyle.fontStyle = FontStyle.Bold;
			//			currentStyle.
		}
		currentStyle2 = new GUIStyle (GUI.skin.box);
		currentStyle2.normal.background = woodTexture;
		currentStyle2.font = myFont;
		currentStyle2.fontSize = 30;
		currentStyle2.normal.textColor = Color.black;
//		currentStyle2.richText = true;
//		currentStyle2.alignment = TextAnchor.MiddleCenter;
		textStyle = new GUIStyle();
		textStyle.normal.textColor = Color.black;
		textStyle.font = myFont;
		textStyle.fontSize = 20;


		textStyle2 = new GUIStyle();
		textStyle2.normal.textColor = Color.black;
		textStyle2.font = myFont;
		textStyle2.fontSize = 35;
		textStyle2.fontStyle = FontStyle.Bold;
		textStyle2.alignment = TextAnchor.MiddleCenter;

		textStyle3 = new GUIStyle();
		textStyle3.normal.textColor = Color.black;
		textStyle3.font = myFont;
		textStyle3.fontSize = 25;
		textStyle3.fontStyle = FontStyle.Bold;

//		textStyle3.alignment = TextAnchor.MiddleCenter;

		textStyle4 = new GUIStyle ();
		textStyle4.normal.textColor = Color.black;
		textStyle4.font = myFont;
		textStyle4.fontSize = 25;
		textStyle4.fontStyle = FontStyle.Bold;
		textStyle4.alignment = TextAnchor.MiddleCenter;


		GUI.skin.label.font = myFont;
		GUI.skin.label.fontSize = 20;
//		GUI.color = Color.cyan;
//		GUI.contentColor = Color.black;
		//		GUI.backgroundColor = Color.white;
		GUI.Box (new Rect (x1, y1, Screen.width / 18 * 2.75f, Screen.height * 0.5f), "Player 1", currentStyle);
		GUI.Label (new Rect (x1 + 40, y1 + 40, width, height), new GUIContent(" : " + StarNumber [0].ToString () , img[0]), textStyle3);
		GUI.Label (new Rect (x1 + 130, y1 + 40, width, height), new GUIContent(" : " + BombNumber [0].ToString () , img[1]), textStyle3);
		GUI.Label (new Rect (x1 + 40, y1 + 80, width, height), new GUIContent(" : " + SpeedOfPlayer [0].ToString () , img[2]), textStyle3);
		GUI.Label (new Rect (x1 + 130, y1 + 80, width, height), new GUIContent(" : " + BombRange [0].ToString () , img[10]), textStyle3);
		GUI.Label (new Rect (x1 + 60, y1 + 120, width, height), "Triger: " + trigerNumber [0].ToString () , textStyle3);

		GUI.Label (new Rect (x1, y1 + 160,  Screen.width / 18 * 2.75f, height), "Key Press", textStyle2);

		int index = 0;
		if (playerLive[0] && playerList [0].GetComponent<PlayerAttribute> ().GetCreateFlag (0))
			index = 11;
		else
			index = 1;
		GUI.Label (new Rect (x1, y1 + 190,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [0].createObject [0].Substring(5), img [index]), textStyle4);
		if (playerLive[0] && playerList [0].GetComponent<PlayerAttribute> ().GetCreateFlag (2))
			index = 12;
		else
			index = 2;
		GUI.Label (new Rect (x1, y1 + 230,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [0].createObject [2].Substring(5), img [index]), textStyle4);
		if (playerLive[0] && playerList [0].GetComponent<PlayerAttribute> ().GetCreateFlag (1))
			index = 13;
		else
			index = 3;
		GUI.Label (new Rect (x1, y1 + 270,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [0].createObject [1].Substring(5), img [index]), textStyle4);
		if (playerLive[0] && playerList [0].GetComponent<PlayerAttribute> ().GetCreateFlag (3))
			index = 14;
		else
			index = 4;
		GUI.Label (new Rect (x1, y1 + 310,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [0].createObject [3].Substring(5), img [index]), textStyle4);
		if (playerLive[0] && playerList [0].GetComponent<PlayerAttribute> ().GetCreateFlag (4))
			index = 15;
		else
			index = 5;
		GUI.Label (new Rect (x1, y1 + 350,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [0].createObject [4].Substring(5), img [index]), textStyle4);
		if (playerLive[0] && playerList [0].GetComponent<PlayerAttribute> ().GetCreateFlag (5))
			index = 17;
		else
			index = 7;
		GUI.Label (new Rect (x1, y1 + 390,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [0].createObject [5].Substring(5), img [index]), textStyle4);
		GUI.Label (new Rect (x1, y1 + 420, Screen.width / 18 * 2.75f, height), "Triger:" + playersControl[0].tick, textStyle4);



//		

		GUI.Box (new Rect (x2, y2, Screen.width / 18 * 2.75f, Screen.height * 0.5f), "Player 2", currentStyle);

//		GUI.Label (new Rect (x2+ 20, y2 + 30, width, height), new GUIContent(" : " + StarNumber [0].ToString () , img[0]), textStyle2);
//		GUI.Label (new Rect (x2+ 20, y2 + 60, width, height), new GUIContent(" : " + StarNumber [0].ToString () , img[1]), textStyle2);
//		GUI.Label (new Rect (x2+ 20, y2 + 90, width, height), new GUIContent(" : " + StarNumber [0].ToString () , img[2]), textStyle2);
//		GUI.Label (new Rect (x2+ 20, y2 + 120, width, height), new GUIContent(" : " + StarNumber [0].ToString () , img[10]), textStyle2);
//		GUI.Label (new Rect (x2+ 20, y2 + 150, width, height), "Triger: " + trigerNumber [1].ToString (), textStyle2);


		GUI.Label (new Rect (x2 + 40, y2 + 40, width, height), new GUIContent(" : " + StarNumber [1].ToString () , img[0]), textStyle3);
		GUI.Label (new Rect (x2 + 130, y2 + 40, width, height), new GUIContent(" : " + BombNumber [1].ToString () , img[1]), textStyle3);
		GUI.Label (new Rect (x2 + 40, y2 + 80, width, height), new GUIContent(" : " + SpeedOfPlayer [1].ToString () , img[2]), textStyle3);
		GUI.Label (new Rect (x2 + 130, y2 + 80, width, height), new GUIContent(" : " +  BombRange[1].ToString () , img[10]), textStyle3);
		GUI.Label (new Rect (x2 + 60, y2 + 120, width, height), "Triger: " + trigerNumber [1].ToString () , textStyle3);

//		GUI.Label (new Rect (x2 + 20, y2 + 150, width, height), "Key Note", textStyle2);
//		GUI.Label (new Rect (x2 + 20, y2 + 180, width, height), new GUIContent(img[1]), textStyle3);
//		GUI.Label (new Rect (x2 + 40, y2 + 190, width, height), playersControl[1].createObject[0], textStyle3);
//		GUI.Label (new Rect (x2 + 60, y2 + 180, width, height), new GUIContent(img[2]), textStyle3);
//		GUI.Label (new Rect (x2 + 80, y2 + 190, width, height), playersControl[0].createObject[2], textStyle3);
//		GUI.Label (new Rect (x2 + 100, y2 + 180, width, height), new GUIContent(img[3]), textStyle3);
//		GUI.Label (new Rect (x2 + 120, y2 + 190, width, height), playersControl[0].createObject[1], textStyle3);
//		GUI.Label (new Rect (x2 + 140, y2 + 180, width, height), new GUIContent(img[4]), textStyle3);
//		GUI.Label (new Rect (x2 + 160, y2 + 190, width, height), playersControl[0].createObject[3], textStyle3);
//		GUI.Label (new Rect (x2 + 20, y2 + 220, width, height), new GUIContent(img[5]), textStyle3);
//		GUI.Label (new Rect (x2 + 40, y2 + 230, width, height), playersControl[0].createObject[4], textStyle3);
//		GUI.Label (new Rect (x2 + 60, y2 + 220, width, height), new GUIContent(img[6]), textStyle3);
//		GUI.Label (new Rect (x2 + 80, y2 + 230, width, height), "L", textStyle3);
//		GUI.Label (new Rect (x2 + 100, y2 + 220, width, height), new GUIContent(img[7]), textStyle3);
//		GUI.Label (new Rect (x2 + 120, y2 + 230, width, height), playersControl[0].createObject[5], textStyle3);
//		GUI.Label (new Rect (x2 + 140, y2 + 220, width, height), new GUIContent(img[8]), textStyle3);
//		GUI.Label (new Rect (x2 + 160, y2 + 230, width, height), "M", textStyle3);
//		GUI.Label (new Rect (x2 + 40, y2 + 260, width, height), "Triger:" + playersControl[1].tick, textStyle3);

		GUI.Label (new Rect (x2, y2 + 160,  Screen.width / 18 * 2.75f, height), "Key Press", textStyle2);

		if (playerLive[1] && playerList [1].GetComponent<PlayerAttribute> ().GetCreateFlag (0))
			index = 11;
		else
			index = 1;
		GUI.Label (new Rect (x2, y2 + 190,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [1].createObject [0], img [index]), textStyle4);
		if (playerLive[1] && playerList [1].GetComponent<PlayerAttribute> ().GetCreateFlag (2))
			index = 12;
		else
			index = 2;
		GUI.Label (new Rect (x2, y2 + 230,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [1].createObject [2], img [index]), textStyle4);
		if (playerLive[1] && playerList [1].GetComponent<PlayerAttribute> ().GetCreateFlag (1))
			index = 13;
		else
			index = 3;
		GUI.Label (new Rect (x2, y2 + 270,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [1].createObject [1], img [index]), textStyle4);
		if (playerLive[1] && playerList [1].GetComponent<PlayerAttribute> ().GetCreateFlag (3))
			index = 14;
		else
			index = 4;
		GUI.Label (new Rect (x2, y2 + 310,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [1].createObject [3], img [index]), textStyle4);
		if (playerLive[1] && playerList [1].GetComponent<PlayerAttribute> ().GetCreateFlag (4))
			index = 15;
		else
			index = 5;
		GUI.Label (new Rect (x2, y2 + 350,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [1].createObject [4], img [index]), textStyle4);
		if (playerLive[1] && playerList [1].GetComponent<PlayerAttribute> ().GetCreateFlag (5))
			index = 17;
		else
			index = 7;
		GUI.Label (new Rect (x2, y2 + 390,  Screen.width / 18 * 2.75f, height), new GUIContent (":" + playersControl [1].createObject [5], img [index]), textStyle4);

		GUI.Label (new Rect (x2, y2 + 420, Screen.width / 18 * 2.75f, height), "Triger:" + playersControl[1].tick, textStyle4);



		GUI.Box (new Rect (x1, Screen.height * 0.5f, Screen.width / 18 * 2.75f, Screen.height * 0.5f), "", currentStyle2);
		GUI.Label(new Rect(x1, Screen.height * 0.5f + y3, Screen.width / 18 * 2.75f, height), "resource", textStyle4);
//		GUI.Label (new Rect (x1 + 20, Screen.height * 0.5f + 30, width, height), "Star: " + StarNumber [0].ToString ());
		GUI.Label(new Rect(x1, Screen.height * 0.5f + 2 * y3, Screen.width / 18 * 2.75f, height), new GUIContent(" = 20", img[9]), textStyle4);
		GUI.Label(new Rect(x1, Screen.height * 0.5f + 3 * y3, Screen.width / 18 * 2.75f, height), new GUIContent(" = 50", img[0]), textStyle4);
		GUI.Label(new Rect(x1, Screen.height * 0.5f + 4 * y3, Screen.width / 18 * 2.75f, height), "promps", textStyle4);
		GUI.Label(new Rect(x1 , Screen.height * 0.5f + 5 * y3, Screen.width / 18 * 2.75f, height), new GUIContent(" = 50", img[1]), textStyle4);
		GUI.Label(new Rect(x1, Screen.height * 0.5f + 6 * y3, Screen.width / 18 * 2.75f, height), new GUIContent(" = 30", img[2]), textStyle4);
		GUI.Label(new Rect(x1, Screen.height * 0.5f + 7 * y3, Screen.width / 18 * 2.75f, height), new GUIContent(" = 30", img[3]), textStyle4);
		GUI.Label(new Rect(x1, Screen.height * 0.5f + 8 * y3, Screen.width / 18 * 2.75f, height), new GUIContent(" = 50", img[4]), textStyle4);
		GUI.Label(new Rect(x1, Screen.height * 0.5f + 9 * y3, Screen.width / 18 * 2.75f, height), new GUIContent(" = 120", img[5]), textStyle4);
		GUI.Label(new Rect(x1, Screen.height * 0.5f + 10 * y3, Screen.width / 18 * 2.75f, height), new GUIContent(" = 150", img[7]), textStyle4);

//		GUI.Label (new Rect (x1 + 5.2f * x3, Screen.height * 0.5f + 6 * y3, width * 1.1f, height), new GUIContent (" = 50", img [11]), textStyle);

	}
}
