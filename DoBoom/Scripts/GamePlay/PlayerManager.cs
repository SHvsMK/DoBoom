using UnityEngine;
using System.Collections;

public class PlayerManager : DoBoom {

	/*public struct PlayerControl {
		public string Up;
		public string Down;
		public string Left;
		public string Right;
		public string place;
		public string[] createObject;
		public string triger;
	}

	protected static int playerNumber;
	private int PlayerStartTime;
	private int PlayerEndTime;
	private bool playerCanCreate;
	protected static PlayerControl playerControl;
	protected static int trigerTime;
	protected GameObject player;
	protected static bool GameStart;
	protected static bool playerLive;

	// Use this for initialization
	void Start () {
		for (var i = 0; i < 2; i++) {
			if (!playernumber [i]) {
				playernumber [i] = true;
				playerNumber = i;
				break;
			}
		}
		playerControl .Up = "W";
		playerControl .Down = "S";
		playerControl .Left = "A";
		playerControl .Right = "D";
		playerControl .place = "Space";
		playerControl .createObject = new string[6];
		playerControl .createObject [0] = "T";
		playerControl .createObject [1] = "Y";
		playerControl .createObject [2] = "U";
		playerControl .createObject [3] = "I";
		playerControl .createObject [4] = "O";
		playerControl .createObject [5] = "P";
		playerControl .triger = "LeftBracket";
		trigerTime = 1;
		GameStart = false;
		playerLive = false;
		PlayerStartTime = System.DateTime.Now.Second;
		PlayerEndTime = PlayerStartTime;
		playerCanCreate = false;
	}

	private void createplayerInstantiate (Vector3 pos, int i) {
		player = (GameObject)Instantiate (prefab [0], pos, Quaternion.identity);
		playerList [i] = player;
		playerLive = true;
		/*player.GetComponent<PlayerAttribute> ().SetplayerNum (i);
		player.GetComponent<PlayerAttribute> ().SetDirection ();
		player.GetComponent<PlayerAttribute> ().SetCreateObject ();
		player.GetComponent<PlayerAttribute> ().SetNumberOfBombs (1);
		player.GetComponent<PlayerAttribute> ().SetRangeOfBomb (1);
		player.GetComponent<PlayerAttribute> ().SetSpeed (2);
		player.GetComponent<PlayerAttribute> ().SetTimeOfReborn (1);
		player.GetComponent<PlayerAttribute> ().SetLeftBombNumber (1);
		player.GetComponent<PlayerAttribute> ().SetNumberOfStars (0);
		player.GetComponent<PlayerAttribute> ().InitialSpecialObject ();
		player.GetComponent<PlayerAttribute> ().SetTriger ();
		player.GetComponent<PlayerAttribute> ().SetSuperTime ();
		player.GetComponent<PlayerAttribute> ();
	}

	// Update is called once per frame
	void Update () {
		var pos = new Vector3 (0, 0, 0);
		switch (playerNumber) {
		case 0:
			pos.x = 2;
			break;
		case 1:
			pos.x = 4;
			break;
		default:
			break;
		}

		PlayerEndTime = System.DateTime.Now.Second;
		if (PlayerEndTime < PlayerStartTime) {
			PlayerEndTime += 60;
		}
		if (PlayerEndTime - PlayerStartTime >= 5 || !GameStart) {
			playerCanCreate = true;
		} else {
			playerCanCreate = false;
		}
		if (playerLive) {
			PlayerStartTime = PlayerEndTime;
		}
		if (!playerLive && playerCanCreate) {
			createplayerInstantiate (pos, playerNumber);
			PlayerStartTime = PlayerEndTime;
		}
		GameStart = true;
		if (Game < 2)
			Game++;
	}*/
}
