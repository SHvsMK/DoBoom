using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildSolidBlock : GamePlay {
	
//	public bool[][] isSolidBlock;
//	public GameObject temp;
	private ObjectPos woodboxpos;
	private ObjectPos solidboxpos;
	private ObjectPos icepos;
	private ObjectPos pitfulpos;
	private ObjectPos basepos;
	private ObjectPos treasurepos;
	private ObjectPos[] SpecialPoint;
	private Vector3 pos = new Vector3 ();
	// Use this for initialization

	private void CreateBox(Vector3 boxpos, int i) {
		var index = Random.Range (10, 12);
		pos = boxpos;
		var box = (GameObject)Instantiate (prefab[index], pos, Quaternion.identity);
		solidboxpos.x = pos.x;
		solidboxpos.y = pos.y;
		SolidBoxList [solidboxpos] = box;
	}

	private bool CheckPos(ObjectPos woodpos) {
		if (SolidBoxList.ContainsKey (woodpos))
			return false;
		if (IceList.ContainsKey (woodpos))
			return false;
		if (PitfulList.ContainsKey (woodpos))
			return false;
		if (WoodBoxList.ContainsKey (woodpos))
			return false;
		if (ItemList.ContainsKey (woodpos))
			return false;
		if (SpecialPointList.ContainsKey (woodpos))
			return false;
		return true;
	}

	private void BuildSpecialPointList () {
		SpecialPoint = new ObjectPos[12];

		SpecialPoint[0].x = -7;
		SpecialPoint[0].y = 7;
		SpecialPoint[1].x = -8;
		SpecialPoint[1].y = 6;
		SpecialPoint[2].x = -7;
		SpecialPoint[2].y = 6;
		SpecialPoint[3].x = -6;
		SpecialPoint[3].y = 6;
		SpecialPoint[4].x = -6;
		SpecialPoint[4].y = 4;
		SpecialPoint[5].x = -6;
		SpecialPoint[5].y = 3;
		SpecialPoint[6].x = 7;
		SpecialPoint[6].y = -7;
		SpecialPoint[7].x = 8;
		SpecialPoint[7].y = -6;
		SpecialPoint[8].x = 7;
		SpecialPoint[8].y = -6;
		SpecialPoint[9].x = 6;
		SpecialPoint[9].y = -6;
		SpecialPoint[10].x = 6;
		SpecialPoint[10].y = -4;
		SpecialPoint[11].x = 6;
		SpecialPoint[11].y = -3;

		for (var i = 0; i < 12; i++) {
			SpecialPointList [SpecialPoint [i]] = true;
		}

	}

	private void BuildSpecificWoodBox (Vector3 woodpos) {
		pos = woodpos;
		var woodbox = (GameObject)Instantiate (prefab[1], pos, Quaternion.identity);
		woodboxpos.x = pos.x;
		woodboxpos.y = pos.y;
		WoodBoxList [woodboxpos] = woodbox;
	}

	void Start () {
		buildFloor ();
		pos = Vector3.zero;

		BuildSpecialPointList ();

		//Base
		pos = new Vector3 (-8, 7, 2);
		var Base = (GameObject)Instantiate (prefab[3], pos, Quaternion.identity);
		Bases [0] = Base;
		basepos.x = pos.x;
		basepos.y = pos.y;
		Bases[0].GetComponent<BaseAttribute> ().SetBaseHealth ();
		Bases [0].GetComponent<BaseAttribute> ().SetBaseNumber (0);
		Bases [0].GetComponent<BaseAttribute> ().SetBaseHealthPresent ();
		BaseList [basepos] = Base;
		baseLive [0] = true;
		pos = new Vector3 (8, -7, 2);
		Base = (GameObject)Instantiate (prefab[3], pos, Quaternion.identity);
		Bases [1] = Base;
		basepos.x = pos.x;
		basepos.y = pos.y;
		Bases[1].GetComponent<BaseAttribute> ().SetBaseHealth ();
		Bases [1].GetComponent<BaseAttribute> ().SetBaseNumber (1);
		Bases [1].GetComponent<BaseAttribute> ().SetBaseHealthPresent ();
		BaseList [basepos] = Base;
		baseLive [1] = true;

		//Ice
		for (int i = -9; i <= 9;i ++) {
			pos = new Vector3 (i, 8, 2);
			var ice = (GameObject)Instantiate (prefab[6], pos, Quaternion.identity);
			if (-8 <= i && i <= 8)
				ice.GetComponent<SpriteRenderer> ().color = Color.green;
			icepos.x = pos.x;
			icepos.y = pos.y;
			IceList [icepos] = ice;
			pos = new Vector3 (i, -8, 2);
			ice = (GameObject)Instantiate (prefab[6], pos, Quaternion.identity);
			if (-8 <= i && i <= 8)
				ice.GetComponent<SpriteRenderer> ().color = Color.green;
			icepos.x = pos.x;
			icepos.y = pos.y;
			IceList [icepos] = ice;
		}
		for (int i = -8; i <= 8;i ++) {
			pos = new Vector3 (9, i, 2);
			var ice = (GameObject)Instantiate (prefab[6], pos, Quaternion.identity);
			icepos.x = pos.x;
			icepos.y = pos.y;
			IceList [icepos] = ice;
			pos = new Vector3 (-9, i, 2);
			ice = (GameObject)Instantiate (prefab[6], pos, Quaternion.identity);
			icepos.x = pos.x;
			icepos.y = pos.y;
			IceList [icepos] = ice;
		}

		//Pitful
		for (int i = -5; i <= 5; i++) {
			pos = new Vector3 (-0, i, 2);
			var pitful = (GameObject)Instantiate (prefab[7], pos, Quaternion.identity);
			pitfulpos.x = pos.x;
			pitfulpos.y = pos.y;
			PitfulList [pitfulpos] = pitful;
		}
		for (int i = -3; i <= 3; i++) {
			pos = new Vector3 (i, 0, 2);
			var pitful = (GameObject)Instantiate (prefab[7], pos, Quaternion.identity);
			pitfulpos.x = pos.x;
			pitfulpos.y = pos.y;
			PitfulList [pitfulpos] = pitful;
		}

		pos = new Vector3 (-8, -4, 2);
		var treasure = (GameObject)Instantiate (prefab[4], pos, Quaternion.identity);
		treasurepos.x = pos.x;
		treasurepos.y = pos.y;
		treasure.GetComponent<WoodBoxExplosion> ().SetItemSpecial ();
		WoodBoxList [treasurepos] = treasure;

		pos = new Vector3 (8, 4, 2);
		treasure = (GameObject)Instantiate (prefab[4], pos, Quaternion.identity);
		treasurepos.x = pos.x;
		treasurepos.y = pos.y;
		treasure.GetComponent<WoodBoxExplosion> ().SetItemSpecial ();
		WoodBoxList [treasurepos] = treasure;

		CreateBox (new Vector3 (-8, 4, 2), 5);
		CreateBox (new Vector3 (-4, 6, 2), 5);
		CreateBox (new Vector3 (-6, 7, 2), 5);
		CreateBox (new Vector3 (-8, 5, 2), 5);
		CreateBox (new Vector3 (-7, 5, 2), 5);
		CreateBox (new Vector3 (-5, 5, 2), 5);
		CreateBox (new Vector3 (5, 6, 2), 5);
		CreateBox (new Vector3 (2, 5, 2), 5);
		CreateBox (new Vector3 (-7, 3, 2), 5);
		CreateBox (new Vector3 (-5, 3, 2), 5);
		CreateBox (new Vector3 (5, 4, 2), 5);
		CreateBox (new Vector3 (7, 4, 2), 5);
		CreateBox (new Vector3 (2, 3, 2), 5);
		CreateBox (new Vector3 (6, 0, 2), 5);
		CreateBox (new Vector3 (7, -3, 2), 5);
		CreateBox (new Vector3 (5, -3, 2), 5);
		CreateBox (new Vector3 (2, -4, 2), 5);
		CreateBox (new Vector3 (-2, -3, 2), 5);
		CreateBox (new Vector3 (-5, -4, 2), 5);
		CreateBox (new Vector3 (-7, -4, 2), 5);
		CreateBox (new Vector3 (-2, -5, 2), 5);
		CreateBox (new Vector3 (-8, -3, 2), 5);
		CreateBox (new Vector3 (-7, -6, 2), 5);
		CreateBox (new Vector3 (5, -5, 2), 5);
		CreateBox (new Vector3 (7, -5, 2), 5);
		CreateBox (new Vector3 (6, -7, 2), 5);
		CreateBox (new Vector3 (8, -5, 2), 5);
		CreateBox (new Vector3 (8, -4, 2), 5);
		CreateBox (new Vector3 (4, -6, 2), 5);
		CreateBox (new Vector3 (-7, -5, 2), 5);
		CreateBox (new Vector3 (-6, -6, 2), 5);
		CreateBox (new Vector3 (7, 6, 2), 5);
		CreateBox (new Vector3 (7, 5, 2), 5);
		CreateBox (new Vector3 (6, 6, 2), 5);
		CreateBox (new Vector3 (-1, 2, 2), 5);
		CreateBox (new Vector3 (1, -2, 2), 5);

		CreateBox ( new Vector3 (3, 7, 2), 5);
		CreateBox ( new Vector3 (-5, -6, 2), 5);
		CreateBox ( new Vector3 (-1, 6, 2), 5);
		CreateBox ( new Vector3 (-2, 7, 2), 5);
		CreateBox ( new Vector3 (1, 6, 2), 5);
		CreateBox ( new Vector3 (-2, 4, 2), 5);
		CreateBox ( new Vector3 (-4, 1, 2), 5);
		CreateBox ( new Vector3 (8, 3, 2), 5);
		CreateBox ( new Vector3 (-8, 0, 2), 5);
		CreateBox ( new Vector3 (-6, 0, 2), 5);
		CreateBox ( new Vector3 (4, 1, 2), 5);
		CreateBox ( new Vector3 (4, -1, 2), 5);
		CreateBox ( new Vector3 (-4, -1, 2), 5);
		CreateBox ( new Vector3 (8, 0, 2), 5);
		CreateBox ( new Vector3 (-3, -7, 2), 5);
		CreateBox ( new Vector3 (2, -7, 2),5);
		CreateBox ( new Vector3 (1, -6, 2), 5);
		CreateBox ( new Vector3 (-1, -6, 2),5);


		BuildSpecificWoodBox (new Vector3 (-5, 7, 2));
		BuildSpecificWoodBox (new Vector3 (-5, 6, 2));
		BuildSpecificWoodBox (new Vector3 (-5, 4, 2));
		BuildSpecificWoodBox (new Vector3 (-4, 7, 2));
		BuildSpecificWoodBox (new Vector3 (-6, 5, 2));
		BuildSpecificWoodBox (new Vector3 (-6, 2, 2));
		BuildSpecificWoodBox (new Vector3 (-7, 4, 2));

		BuildSpecificWoodBox (new Vector3 (5, -7, 2));
		BuildSpecificWoodBox (new Vector3 (5, -6, 2));
		BuildSpecificWoodBox (new Vector3 (5, -4, 2));
		BuildSpecificWoodBox (new Vector3 (4, -7, 2));
		BuildSpecificWoodBox (new Vector3 (6, -5, 2));
		BuildSpecificWoodBox (new Vector3 (6, -2, 2));
		BuildSpecificWoodBox (new Vector3 (7, -4, 2));

		pos.z = 2;
		int count = 0;
		while (count < 50) {
			int x = Random.Range (-8, 8);
			int y = Random.Range (-7, 7);
			pos.x = x;
			pos.y = y;
			woodboxpos.x = pos.x;
			woodboxpos.y = pos.y;
			if (CheckPos (woodboxpos)) {
				var woodbox = (GameObject)Instantiate (prefab [1], pos, Quaternion.identity);
				WoodBoxList [woodboxpos] = woodbox;
				count++;
			}
		}

		count = 0;
		while (count < 5) {
			int x = Random.Range (-8, 8);
			int y = Random.Range (-7, 7);
			pos.x = x;
			pos.y = y;
			pitfulpos.x = pos.x;
			pitfulpos.y = pos.y;
			if (CheckPos (pitfulpos)) {
				var banana = (GameObject)Instantiate (prefab [8], pos, Quaternion.identity);
				banana.GetComponent<ItemAttribute> ().SetItemNumber (9);
				ItemList [pitfulpos] = banana;
				count++;
			}
		}

		count = 0;
		while (count < 5) {
			int x = Random.Range (-8, 8);
			int y = Random.Range (-7, 7);
			pos.x = x;
			pos.y = y;
			pitfulpos.x = pos.x;
			pitfulpos.y = pos.y;
			if (CheckPos (pitfulpos)) {
				var reverse = (GameObject)Instantiate (prefab [9], pos, Quaternion.identity);
				reverse.GetComponent<ItemAttribute> ().SetItemNumber (8);
				ItemList [pitfulpos] = reverse;
				count++;
			}
		}
	}
	void buildFloor()
	{
		for (int i = -10; i <= 10; i++) {
			for (int j = -10; j <= 10; j++) {
				Instantiate (prefab[2], new Vector3 (i, j, 10), Quaternion.identity);
			}

		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
