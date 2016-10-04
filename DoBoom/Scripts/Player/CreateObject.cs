using UnityEngine;
using System.Collections;
using System;

public class CreateObject : GamePlay {

	private KeyCode[] createObject;
	private int[] StarToObject;

	// Use this for initialization
	void Start () {
		createObject = new KeyCode[6];
		for (var i = 0; i < 6; i++) {
			createObject[i] = (KeyCode)Enum.Parse(typeof(KeyCode), GetComponent<PlayerAttribute> ().GetCreateObject ()[i]);
		}
		StarToObject = new int[6];
		StarToObject [0] = 30;
		StarToObject [1] = 30;
		StarToObject [2] = 30;
		StarToObject [3] = 50;
		StarToObject [4] = 120;
		StarToObject [5] = 150;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameOver)
			return;
		for (var i = 0; i < 6; i++) {
			if (Input.GetKeyDown (createObject [i])) {
				var NumberOfStars = GetComponent<PlayerAttribute> ().GetNumberOfStars ();
				//Number of Bomb
				var createFlag = GetComponent<PlayerAttribute>().GetCreateFlag(i);
				bool createsuccess = false;
				if (createFlag)
					continue;
				if (createObject [i] == createObject [0]) {
					if (NumberOfStars < StarToObject [0])
						break;
					var NumberOfBomb = GetComponent<PlayerAttribute> ().GetNumberOfBombs ();
					if (NumberOfBomb == 8)
						break;
					var LeftBombNumber = GetComponent<PlayerAttribute> ().GetLeftBombNumber ();
					GetComponent<PlayerAttribute> ().SetNumberOfBombs (NumberOfBomb + 1);
					GetComponent<PlayerAttribute> ().SetLeftBombNumber (LeftBombNumber + 1);
					GetComponent<PlayerAttribute> ().SetNumberOfStars (NumberOfStars - StarToObject [0]);
					createsuccess = true;
				}
				//Range1 of Bomb
				if (createObject [i] == createObject [1]) {
					if (NumberOfStars < StarToObject [1])
						break;
					var RangeOfBomb = GetComponent<PlayerAttribute> ().GetRangeOfBomb ();
					if (RangeOfBomb == 7)
						break;
					GetComponent<PlayerAttribute> ().SetRangeOfBomb (RangeOfBomb + 1);
					GetComponent<PlayerAttribute> ().SetNumberOfStars (NumberOfStars - StarToObject [1]);
					createsuccess = true;
				}
				//Speed of Player
				if (createObject [i] == createObject [2]) {
					if (NumberOfStars < StarToObject [2])
						break;
					var Speed = GetComponent<PlayerAttribute> ().GetSpeed ();
					if (Speed == 6.0f)
						break;
					var increase = 0f;
					if (Speed == 2.0f) {
						increase = 1.2f;
					} else if (Speed == 3.2f) {
						increase = 0.8f;
					} else if (Speed == 4.0f) {
						increase = 0.8f;
					} else if (Speed == 4.8f) {
						increase = 0.6f;
					} else if (Speed == 5.4f) {
						increase = 0.6f;
					} else if (Speed == 6.0f) {
					}
					GetComponent<PlayerAttribute> ().SetSpeed (Speed + increase);
					GetComponent<PlayerAttribute> ().SetNumberOfStars (NumberOfStars - StarToObject [2]);
					createsuccess = true;
				}
				//Range2 of Bomb
				if (createObject [i] == createObject [3]) {
					if (NumberOfStars < StarToObject [3])
						break;
					var RangeOfBomb = GetComponent<PlayerAttribute> ().GetRangeOfBomb ();
					if (RangeOfBomb == 7)
						break;
					int rangeCurrent = RangeOfBomb + 2 > 7 ? 7 : RangeOfBomb + 2;
					GetComponent<PlayerAttribute> ().SetRangeOfBomb (rangeCurrent);
					GetComponent<PlayerAttribute> ().SetNumberOfStars (NumberOfStars - StarToObject [3]);
					createsuccess = true;
				}
				//range3 of Bomb
				if (createObject [i] == createObject [4]) {
					if (NumberOfStars < StarToObject [4])
						break;
					var RangeOfBomb = GetComponent<PlayerAttribute> ().GetRangeOfBomb ();
					if (RangeOfBomb == 7)
						break;
					int rangeCurrent = RangeOfBomb + 5 > 7 ? 7 : RangeOfBomb + 5;
					GetComponent<PlayerAttribute> ().SetRangeOfBomb (RangeOfBomb + 5);
					GetComponent<PlayerAttribute> ().SetNumberOfStars (NumberOfStars - StarToObject [4]);
					createsuccess = true;
				}
				//Tick Shoe
				if (createObject [i] == createObject [5]) {
					if (NumberOfStars < StarToObject [5])
						break;
					GetComponent<PlayerAttribute> ().SetSpecialObject (GetComponent<PlayerAttribute> ().GetSpecialObject () + 1);
					GetComponent<PlayerAttribute> ().SetNumberOfStars (NumberOfStars - StarToObject [5]);
					createsuccess = true;
				}
				if (createsuccess)
					GetComponent<PlayerAttribute> ().SetCreateFlag (i);
			}
		}
	}
}
