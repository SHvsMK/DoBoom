using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Motion : GamePlay {

	private Animator ani;
	private Rigidbody2D p;
	private struct direction{
		public KeyCode up;
		public KeyCode down;
		public KeyCode left;
		public KeyCode right;
	}
	private direction playerDirec;
	private ObjectPos itempos;
	private ObjectPos playerPos;
	private AudioSource source;
	public AudioClip collection;
	public AudioClip banana;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
		p = GetComponent<Rigidbody2D> ();
		System.Console.Write (ani.speed);
		ani.SetInteger ("Direction", 1);
		playerDirec.up = (KeyCode)Enum.Parse(typeof(KeyCode), GetComponent<PlayerAttribute>().GetDirection().Up);
		playerDirec.down = (KeyCode)Enum.Parse(typeof(KeyCode), GetComponent<PlayerAttribute>().GetDirection().Down);
		playerDirec.left = (KeyCode)Enum.Parse(typeof(KeyCode), GetComponent<PlayerAttribute>().GetDirection().Left);
		playerDirec.right = (KeyCode)Enum.Parse(typeof(KeyCode), GetComponent<PlayerAttribute>().GetDirection().Right);
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter2D (Collision2D col) {
		ani.speed = 0;
		GetComponent<PlayerAttribute> ().SetSpeedPower (false);
	}

	// Update is called once per frame
	void Update () {
		if (GameOver)
			return;
		var T = GetComponent<Transform> ();
		var offset = GetComponent<BoxCollider2D> ().offset;
		var pos = new Vector3 (
			T.position.x,
			T.position.y + offset.y * T.localScale.y,
			T.position.z);
		playerPos.x = Mathf.Round (pos.x);
		playerPos.y = Mathf.Round (pos.y);
		var reverse = 1;
		bool move = false;
		if (!GetComponent<PlayerAttribute> ().GetSpeedPower ()) {
			if (PitfulList.ContainsKey (playerPos)) {
				ani.speed = 1.7f;
			} else {
				ani.speed = GetComponent<PlayerAttribute> ().GetSpeed ();
			}
			if (GetComponent<PlayerAttribute> ().GetReverse ()) {
				reverse = -1;
			}
			if (Input.GetKey (playerDirec.down)) {
				if (reverse == -1) {
					ani.SetInteger ("Direction", 2);
				} else {
					ani.SetInteger ("Direction", 1);
				}
				p.velocity = new Vector2 (0, -ani.speed * reverse);
				move = true;
			}
			if (Input.GetKeyUp (playerDirec.down)) {
				p.velocity = new Vector2 (0, 0);
				ani.speed = 0;
			}
			if (Input.GetKey (playerDirec.up)) {
				if (reverse == -1) {
					ani.SetInteger ("Direction", 1);
				} else {
					ani.SetInteger ("Direction", 2);
				}
				p.velocity = new Vector2 (0, ani.speed * reverse);
				move = true;
			}
			if (Input.GetKeyUp (playerDirec.up)) {
				p.velocity = new Vector2 (0, 0);
				ani.speed = 0;
			}
			if (Input.GetKey (playerDirec.left)) {
				if (reverse == -1) {
					ani.SetInteger ("Direction", 3);
				} else {
					ani.SetInteger ("Direction", 4);
				}
				p.velocity = new Vector2 (-ani.speed * reverse, 0);
				move = true;
			}
			if (Input.GetKeyUp (playerDirec.left)) {
				p.velocity = new Vector2 (0, 0);
				ani.speed = 0;
			}
			if (Input.GetKey (playerDirec.right)) {
				if (reverse == -1) {
					ani.SetInteger ("Direction", 4);
				} else {
					ani.SetInteger ("Direction", 3);
				}
				p.velocity = new Vector2 (ani.speed * reverse, 0);
				move = true;
			}
			if (Input.GetKeyUp (playerDirec.right)) {
				p.velocity = new Vector2 (0, 0);
				ani.speed = 0;
			}
		}
		if (move == false)
			return;
		pos = new Vector3 (
			T.position.x,
			T.position.y + offset.y * T.localScale.y,
			T.position.z);
		itempos.x = Mathf.Round (pos.x);
		itempos.y = Mathf.Round (pos.y);
		if (ItemList.ContainsKey (itempos)) {
			var ItemType = ItemList [itempos].GetComponent<ItemAttribute> ().GetItemNumber ();

			switch (ItemType) {
			case 0:
				source.PlayOneShot (collection, 0.7f);
				var starsNumber1 = GetComponent<PlayerAttribute> ().GetNumberOfStars ();
				GetComponent<PlayerAttribute> ().SetNumberOfStars (starsNumber1 + 20);
				break;
			case 1:
				source.PlayOneShot (collection, 0.7f);
				var starsNumber2 = GetComponent<PlayerAttribute> ().GetNumberOfStars ();
				GetComponent<PlayerAttribute> ().SetNumberOfStars (starsNumber2 + 50);
				break;
			case 2:
				source.PlayOneShot (collection, 0.7f);
				var NumberOfBomb = GetComponent<PlayerAttribute> ().GetNumberOfBombs ();
				var LeftNumberOfBomb = GetComponent<PlayerAttribute> ().GetLeftBombNumber ();
				if (NumberOfBomb == 8)
					break;
				GetComponent<PlayerAttribute> ().SetNumberOfBombs (NumberOfBomb + 1);
				GetComponent<PlayerAttribute> ().SetLeftBombNumber (LeftNumberOfBomb + 1);
				break;
			case 3:
				source.PlayOneShot (collection, 0.7f);
				var SpeedOfPlayer = GetComponent<PlayerAttribute> ().GetSpeed ();
				if (SpeedOfPlayer == 6.0f)
					break;
				if (SpeedOfPlayer == 2.0f) {
					SpeedOfPlayer = 3.2f;
				} else if (SpeedOfPlayer == 3.2f) {
					SpeedOfPlayer = 4.0f;
				} else if (SpeedOfPlayer == 4.0f) {
					SpeedOfPlayer = 4.8f;
				} else if (SpeedOfPlayer == 4.8f) {
					SpeedOfPlayer = 5.4f;
				} else if (SpeedOfPlayer == 6.0f) {
					SpeedOfPlayer = 6.0f;
				}
				GetComponent<PlayerAttribute> ().SetSpeed (SpeedOfPlayer);
				break;
			case 4:
				source.PlayOneShot (collection, 0.7f);
				var RangeOfBomb1 = GetComponent<PlayerAttribute> ().GetRangeOfBomb ();
				if (RangeOfBomb1 == 7)
					break;
				GetComponent<PlayerAttribute> ().SetRangeOfBomb (RangeOfBomb1 + 1);
				break;
			case 5:
				source.PlayOneShot (collection, 0.7f);
				var RangeOfBomb2 = GetComponent<PlayerAttribute> ().GetRangeOfBomb ();
				if (RangeOfBomb2 == 7)
					break;
				int rangeCurrent1 = RangeOfBomb2 + 2 > 7 ? 7 : RangeOfBomb2 + 2;
				GetComponent<PlayerAttribute> ().SetRangeOfBomb (rangeCurrent1);
				break;
			case 6:
				source.PlayOneShot (collection, 0.7f);
				var RangeOfBomb3 = GetComponent<PlayerAttribute> ().GetRangeOfBomb ();
				if (RangeOfBomb3 == 7)
					break;
				int rangeCurrent2 = RangeOfBomb3 + 2 > 7 ? 7 : RangeOfBomb3 + 5;
				GetComponent<PlayerAttribute> ().SetRangeOfBomb (rangeCurrent2);
				break;
			case 7:
				source.PlayOneShot (collection, 0.7f);
				var NumberOfSpecialObject = GetComponent<PlayerAttribute> ().GetSpecialObject ();
				GetComponent<PlayerAttribute> ().SetSpecialObject (NumberOfSpecialObject + 1);
				break;
			case 8:
				source.PlayOneShot (collection, 0.7f);
				GetComponent<PlayerAttribute> ().SetReverse (true);
				break;
			case 9:
				source.PlayOneShot (banana, 0.7f);
				var dir = ani.GetInteger ("Direction");
				ani.speed = 20;
				GetComponent<PlayerAttribute> ().SetSpeedPower (true);
				switch (dir) {
				case 1:
					p.velocity = new Vector2 (0, -ani.speed);
					break;
				case 2:
					p.velocity = new Vector2 (0, ani.speed);
					break;
				case 3:
					p.velocity = new Vector2 (ani.speed, 0);
					break;
				default:
					p.velocity = new Vector2 (-ani.speed, 0);
					break;
				}
				break;
			case 10:
				source.PlayOneShot (collection, 0.7f);
				var starsNumber3 = GetComponent<PlayerAttribute> ().GetNumberOfStars ();
				GetComponent<PlayerAttribute> ().SetNumberOfStars (starsNumber3 + 200);
				break;
			default:
				break;
			}
			Destroy (ItemList [itempos]);
		}
	}

}
