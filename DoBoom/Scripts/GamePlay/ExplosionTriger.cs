using UnityEngine;
using System.Collections;
using System;

public class ExplosionTriger : DoBoom {

	private KeyCode[] triger;
	private ObjectPos firePos;

	private ObjectPos itempos;
	private ObjectPos playerPos;
	public AudioClip trigger;
	private AudioSource source;
	// Use this for initialization
	void Start () {
		triger = new KeyCode[2];
		for (var i = 0; i < 2; i++) {
			triger[i] = (KeyCode)Enum.Parse(typeof(KeyCode), playersControl[i].triger );
		}
		source = GetComponent<AudioSource> ();
	}

	private bool checkPos (int i, int j) {
		firePos.x = i;
		firePos.y = j;
		if (WoodBoxList.ContainsKey (firePos))
			return false;
		if (SolidBoxList.ContainsKey (firePos))
			return false;
		if (BaseList.ContainsKey (firePos))
			return false;
		if (IceList.ContainsKey (firePos))
			return false;
		return true;
	}

	private void destroyPlayer(float x, float y) {
		for (var i = 0; i <= 1; i++) {
			if (!playerLive [i])
				continue;
			var Tplayer = playerList [i].GetComponent<Transform> ();
			var offset = playerList [i].GetComponent<BoxCollider2D> ().offset;
			var superTime = playerList [i].GetComponent<PlayerAttribute> ().GetSuperTime ();
			if (superTime != 0)
				continue;
			var posx = new Vector3 (
				Tplayer.position.x,
				Tplayer.position.y + offset.y * Tplayer.localScale.y,
				Tplayer.position.z);
			playerPos.x = Mathf.Round (posx.x);
			playerPos.y = Mathf.Round (posx.y);
			if (playerPos.x == x && playerPos.y == y) {
				DestroyImmediate (playerList [i]);
				playerLive [i] = false;
			}
		}
	}

	private void destroyItem (ObjectPos itempos) {
		if (ItemList.ContainsKey (itempos)) {
			var ItemNumber = ItemList [itempos].GetComponent<ItemAttribute> ().GetItemNumber ();
			if (ItemNumber != 8 && ItemNumber != 9)
				Destroy (ItemList [itempos]);
		}
		destroyPlayer (itempos.x, itempos.y);
	}

	// Update is called once per frame
	void Update () {
		for (var k = 0; k < 2; k++) {
			if (Input.GetKeyDown (triger [k]) && trigerTime[k] != 0) {
				trigerTime [k]--;
				source.PlayOneShot (trigger, 6.5f);
				for (int i = -10; i <= 10; i++) {
					for (int j = -10; j <= 10; j++) {
						if (checkPos (i, j)) {
							GameObject fire = (GameObject)Instantiate (prefab[0],
								new Vector3(i, j, GetComponent<Transform>().position.z),
								Quaternion.identity);
							itempos.x = i;
							itempos.y = j;
							destroyItem (itempos);
							Destroy (fire, 0.5f);
						}
					}
				}
			}
		}
	}
}
