using UnityEngine;
using System.Collections;

public class RandomProduceObject : DoBoom {

	private int startTime;
	private int endTime;
	private ObjectPos RandomPlace;
	private GameObject item;
	public int IntervalDown = 15;
	public int IntervalUp = 18;
	private struct probability {
		public int down;
		public int up;
	}

	private probability[] ItemProbability;

	// Use this for initialization
	void Start () {
		ItemProbability = new probability[7];
		ItemProbability[0].down = 0;
		ItemProbability[0].up = 40;
		ItemProbability[1].down = 40;
		ItemProbability[1].up = 140;
		ItemProbability[2].down = 140;
		ItemProbability[2].up = 240;
		ItemProbability[3].down = 240;
		ItemProbability[3].up = 340;
		ItemProbability[4].down = 340;
		ItemProbability[4].up = 390;
		ItemProbability[5].down = 390;
		ItemProbability[5].up = 410;
		ItemProbability[6].down = 410;
		ItemProbability[6].up = 420;
		startTime = System.DateTime.Now.Second;
		endTime = System.DateTime.Now.Second;
	}

	private bool checkPosition(ObjectPos pos) {
		if (WoodBoxList.ContainsKey (pos))
			return false;
		if (SolidBoxList.ContainsKey (pos))
			return false;
		if (SpecialBoxList.ContainsKey (pos))
			return false;
		if (ItemList.ContainsKey (pos))
			return false;
		if (IceList.ContainsKey (pos))
			return false;
		if (BaseList.ContainsKey (pos))
			return false;
		return true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameOver)
			return;
		if (WoodBoxList.Count <= 8 ) {
			IntervalDown = 4;
			IntervalUp = 6;
		}
		if (!GameStart)
			return;
		endTime = System.DateTime.Now.Second;
		if (endTime < startTime) {
			endTime += 60;
		}
		var interval = Random.Range (IntervalDown, IntervalUp);
		if (endTime - startTime < interval)
			return;
		var type = Random.Range (0, 420);
		RandomPlace.x = Random.Range (-8, 8);
		RandomPlace.y = Random.Range (-7, 7);
		while (!checkPosition (RandomPlace)) {
			RandomPlace.x = Random.Range (-8, 8);
			RandomPlace.y = Random.Range (-7, 7);
		}
		var itemposition = new Vector3 (RandomPlace.x, RandomPlace.y, 1);
		for (var i = 0; i <= 6; i++) {
			if (ItemProbability [i].down <= type && type < ItemProbability [i].up) {
				item = (GameObject)Instantiate (prefab [i], itemposition, Quaternion.identity);
				item.GetComponent<ItemAttribute> ().SetItemNumber (i + 1);
				ItemList [RandomPlace] = item;
				break;
			}
		}
		startTime = System.DateTime.Now.Second;
	}
}
