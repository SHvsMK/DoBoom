using UnityEngine;
using System.Collections;

public class BombCollider : DoBoom {

	private ObjectPos[] playerPos;

	// Use this for initialization
	void Start () {
		playerPos = new ObjectPos[2];
	}
	
	// Update is called once per frame
	void Update () {
		for (var i = 0; i < 2; i++) {
			if (playerLive [i]) {
				var T = playerList[i].GetComponent<Transform> ();
				var offset = playerList[i].GetComponent<BoxCollider2D> ().offset;
				var posplayer = new Vector3 (
					T.position.x,
					T.position.y + offset.y * T.localScale.y,
					T.position.z);
				playerPos[i].x = Mathf.Round (posplayer.x);
				playerPos[i].y = Mathf.Round (posplayer.y);
			}
		}
		foreach (var bomb in BombList) {
			var pos = bomb.Key;
			var bombObejct = bomb.Value;
			var flag = true;
			if (bombObejct.layer == 0)
				continue;
			for (var i = 0; i < 2; i++) {
				if (playerLive [i]) {
					if (pos.x == playerPos [i].x && pos.y == playerPos [i].y) {
						flag = false;
					}
				}
			}
			if (flag) {
				BombList [pos].layer = 0;
			}
		}
	}
}
