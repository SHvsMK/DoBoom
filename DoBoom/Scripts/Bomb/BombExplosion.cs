using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombExplosion : GamePlay {

	private int time;
	private Transform T;
	private ObjectPos bombpos;
	private ObjectPos playerPos;
	private ObjectPos objectPos;
	private AudioSource source;
	public AudioClip bomb_explosion;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	void Update () {
//		source.PlayOneShot (bomb_explosion, 2.5f);
		Destroy (this.gameObject, 1.45f);
	}

	private bool checkPosition(Vector3 pos, int range) {
		if (range == 0) {
			return false;
		}
		objectPos.x = pos.x;
		objectPos.y = pos.y;
		if (SolidBoxList.ContainsKey (objectPos))
			return false;
		if (IceList.ContainsKey (objectPos))
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

	private int destroyItem (Vector3 nextpos, int leftRange) {
		GameObject fire = (GameObject)Instantiate (prefab [0], nextpos, Quaternion.identity);
		objectPos.x = nextpos.x;
		objectPos.y = nextpos.y;
		if (WoodBoxList.ContainsKey (objectPos)) {
			Destroy (WoodBoxList[objectPos]);
			leftRange = 1;
		}
		if (SpecialBoxList.ContainsKey (objectPos)) {
			Destroy (SpecialBoxList[objectPos]);
			leftRange = 1;
		}
		if (BombList.ContainsKey (objectPos)) {
			Destroy (BombList[objectPos]);
		}
		if (ItemList.ContainsKey (objectPos)) {
			var ItemNumber = ItemList [objectPos].GetComponent<ItemAttribute> ().GetItemNumber ();
			if (ItemNumber != 8 && ItemNumber != 9)
				Destroy (ItemList [objectPos]);
		}
		if (BaseList.ContainsKey (objectPos)) {
			BaseList [objectPos].GetComponent<BaseAttribute> ().DamageBase ();
		}
		destroyPlayer (objectPos.x, objectPos.y);
		nextpos.y++;
		leftRange--;
		return leftRange;
	}

	void OnDestroy() {
		var belongToPlayer = GetComponent<BombAttribute> ().GetBelongToPlayer ();
		int LeftBombnumber;
		if (playerLive [belongToPlayer]) {
			LeftBombnumber = playerList[belongToPlayer].GetComponent<PlayerAttribute> ().GetLeftBombNumber ();
			playerList[belongToPlayer].GetComponent<PlayerAttribute> ().SetLeftBombNumber (LeftBombnumber + 1);
		}
		var pos = GetComponent<Transform> ().position;
		bombpos.x = Mathf.Round (pos.x);
		bombpos.y = Mathf.Round (pos.y);
		var range = GetComponent<BombAttribute> ().GetRange();
		if (BombList.ContainsKey(bombpos))
			BombList.Remove (bombpos);
		T = GetComponent<Transform> ();
		T.position = new Vector3 (Mathf.Round (T.position.x), Mathf.Round (T.position.y), T.position.z);
		GameObject fire0 = (GameObject)Instantiate (prefab[0],
			new Vector3(T.position.x, T.position.y, T.position.z),
			Quaternion.identity);
		var nextpos = new Vector3 (T.position.x, T.position.y, T.position.z);
		destroyPlayer (nextpos.x, nextpos.y);

		//Up
		nextpos = new Vector3 (T.position.x, T.position.y + 1, T.position.z);
		var leftRange = range;
		while (checkPosition (nextpos, leftRange)) {
			leftRange = destroyItem (nextpos, leftRange);
			nextpos.y++;
		}

		//Down
		nextpos = new Vector3 (T.position.x, T.position.y - 1, T.position.z);
		leftRange = range;
		while (checkPosition (nextpos, leftRange)) {
			leftRange = destroyItem (nextpos, leftRange);
			nextpos.y--;
		}

		//Left
		nextpos = new Vector3 (T.position.x - 1, T.position.y, T.position.z);
		leftRange = range;
		while (checkPosition (nextpos, leftRange)) {
			leftRange = destroyItem (nextpos, leftRange);
			nextpos.x--;
		}

		//Right
		nextpos = new Vector3 (T.position.x + 1, T.position.y, T.position.z);
		leftRange = range;
		while (checkPosition (nextpos, leftRange)) {
			leftRange = destroyItem (nextpos, leftRange);
			nextpos.x++;
		}
	}
}
