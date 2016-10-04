using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatePlayer : DoBoom {

	private GameObject[] players;
	private ObjectPos playerPos;
	private bool[] playerCanCreate;

	// Update is called once per frame

	// Use this for initialization
	void Start () {
		players = new GameObject[4];
		playerCanCreate = new bool[2];
		//playerLive = new bool[4];
		PlayerStartTime = new int[2];
		PlayerEndTime = new int[2];
		for (var i = 0; i < 2; i++) {
			PlayerStartTime[i] = System.DateTime.Now.Second;
			PlayerEndTime[i] = PlayerStartTime[i];
			playerCanCreate [i] = false;
		}
	}

	private void createplayerInstantiate (Vector3 pos, int i) {
		players [i] = (GameObject)Instantiate (prefab [0], pos, Quaternion.identity);
		playerList [i] = players [i];
		players [i].layer = 8 + i;
		playerLive [i] = true;
		players [i].GetComponent<PlayerAttribute> ().SetplayerNum (i);
		players [i].GetComponent<PlayerAttribute> ().SetDirection ();
		players [i].GetComponent<PlayerAttribute> ().SetCreateObject ();
		players [i].GetComponent<PlayerAttribute> ().SetNumberOfBombs (1);
		players [i].GetComponent<PlayerAttribute> ().SetRangeOfBomb (1);
		players [i].GetComponent<PlayerAttribute> ().SetSpeed (2.0f);
		players [i].GetComponent<PlayerAttribute> ().SetTimeOfReborn (1);
		players [i].GetComponent<PlayerAttribute> ().SetLeftBombNumber (1);
		players [i].GetComponent<PlayerAttribute> ().SetNumberOfStars (0);
		players [i].GetComponent<PlayerAttribute> ().InitialSpecialObject ();
		players [i].GetComponent<PlayerAttribute> ().SetTriger ();
		players [i].GetComponent<PlayerAttribute> ().SetTick ();
		players [i].GetComponent<PlayerAttribute> ().SetSuperTime ();
		players [i].GetComponent<PlayerAttribute> ().SetReverse (false);
		players [i].GetComponent<PlayerAttribute> ().SetSpeedPower (false);
		players [i].GetComponent<PlayerAttribute> ().InitialCreateFlag ();
	}

	// Update is called once per frame
	void Update () {
		var pos = new Vector3 (-7, 8, 0);
		for (var i = 0; i < 2; i++) {
			PlayerEndTime[i] = System.DateTime.Now.Second;
			if (PlayerEndTime [i] < PlayerStartTime[i]) {
				PlayerEndTime [i] += 60;
			}
			if (PlayerEndTime [i] - PlayerStartTime [i] >= 5 || !GameStart) {
				playerCanCreate [i] = true;
			} else {
				playerCanCreate [i] = false;
			}
		}
		for (var i = 0; i < 2; i++) {
			if (playerLive [i]) {
				PlayerStartTime [i] = PlayerEndTime [i];
			}
		}
		if (!playerLive [0] && playerCanCreate[0]) {
			createplayerInstantiate (pos, 0);
			PlayerEndTime [0] = 0;
			PlayerStartTime [0] = PlayerEndTime [0];
		}
		pos.x = 7;
		pos.y = -7;
		if (!playerLive [1] && playerCanCreate[1]) {
			createplayerInstantiate (pos, 1);
			PlayerEndTime [1] = 0;
			PlayerStartTime [1] = PlayerEndTime [1];
		}
		GameStart = true;
	}
}
