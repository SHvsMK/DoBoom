using UnityEngine;
using System.Collections;
using System;

public class Tick : GamePlay {

	private KeyCode tick;
	private ObjectPos objectPos;
	private Animator ani;
	private int direc;
	public AudioClip kick;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		tick = (KeyCode)Enum.Parse(typeof(KeyCode), GetComponent<PlayerAttribute>().GetTick());
		ani = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameOver)
			return;
		var number = GetComponent<PlayerAttribute> ().GetSpecialObject ();
		if (Input.GetKeyDown (tick)) {
			if (number == 0)
				return;
			source.PlayOneShot (kick, 0.7f);
			var T = GetComponent<Transform> ();
			var offset = GetComponent<BoxCollider2D> ().offset;
			var pos = new Vector3 (
				T.position.x,
				T.position.y + offset.y * T.localScale.y,
				T.position.z);
			objectPos.x = Mathf.Round (pos.x);
			objectPos.y = Mathf.Round (pos.y);
			direc = ani.GetInteger ("Direction");
			switch (direc) {
			case 1:
				objectPos.y--;
				break;
			case 2:
				objectPos.y++;
				break;
			case 3:
				objectPos.x++;
				break;
			case 4:
				objectPos.x--;
				break;
			default:
				break;
			}
			if (BombList.ContainsKey (objectPos)) {
				GetComponent<PlayerAttribute> ().SetSpecialObject (GetComponent<PlayerAttribute> ().GetSpecialObject () - 1);
				var BombSpeed = 4;
				switch (direc) {
				case 1:
					BombList [objectPos].GetComponent<Rigidbody2D> ().velocity = new Vector2(0, -BombSpeed);
					break;
				case 2:
					BombList [objectPos].GetComponent<Rigidbody2D> ().velocity = new Vector2(0, BombSpeed);
					break;
				case 3:
					BombList [objectPos].GetComponent<Rigidbody2D> ().velocity = new Vector2(BombSpeed, 0);
					break;
				case 4:
					BombList [objectPos].GetComponent<Rigidbody2D> ().velocity = new Vector2(-BombSpeed, 0);
					break;
				default:
					break;
				}
				BombList [objectPos].layer = 0;
				BombList.Remove (objectPos);
			}
		}
	}
}
