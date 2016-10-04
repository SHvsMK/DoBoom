using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlaceBomb : GamePlay {
	
	private Transform T;
	private ObjectPos bombpos;
	private KeyCode place;
	private int leftBombNumbers;
	public AudioClip placeBomb;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		T = GetComponent<Transform> ();
		source = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (GameOver)
			return;
		place = (KeyCode)Enum.Parse(typeof(KeyCode), GetComponent<PlayerAttribute>().GetPlaceBoom());
		leftBombNumbers = GetComponent<PlayerAttribute> ().GetLeftBombNumber ();
		if (Input.GetKeyDown (place) && leftBombNumbers != 0) {
			var offset = GetComponent<BoxCollider2D> ().offset;
			var pos = new Vector3 (
				T.position.x,
				T.position.y + offset.y * T.localScale.y,
				T.position.z);
			pos.x = Mathf.Round (pos.x);
			pos.y = Mathf.Round (pos.y);
			bombpos.x = pos.x;
			bombpos.y = pos.y;
			source.PlayOneShot (placeBomb, 0.7f);
			if (!BombList.ContainsKey (bombpos)) {
				GameObject bomb = (GameObject)Instantiate (prefab[0], pos, Quaternion.identity);
				GetComponent<PlayerAttribute> ().SetLeftBombNumber (leftBombNumbers - 1);
				var playernum = GetComponent<PlayerAttribute> ().GetplayerNum ();
				bomb.GetComponent<BombAttribute> ().SetBelongToPlayer (playernum);
				var BombRange = GetComponent<PlayerAttribute> ().GetRangeOfBomb ();
				bomb.GetComponent<BombAttribute> ().SetRange (BombRange);
				bomb.layer = 10 + playernum;
				BombList [bombpos] = bomb;
			}
		}
	}
}
