using UnityEngine;
using System.Collections;

public class WoodBoxExplosion : GamePlay {

	private ObjectPos itempos;
	private bool ItemSpecial;
	// Use this for initialization

	public void SetItemSpecial () {
		ItemSpecial = true;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy () {
		if (GameOver)
			return;
		var pos = GetComponent<Transform> ().position;
		itempos.x = pos.x;
		itempos.y = pos.y;
		WoodBoxList.Remove (itempos);
		GameObject item = (GameObject)Instantiate(prefab [0], pos, Quaternion.identity);
		if (ItemSpecial)
			item.GetComponent<ItemAttribute> ().SetItemNumber (10);
		else
			item.GetComponent<ItemAttribute> ().SetItemNumber (0);
		ItemList [itempos] = item;
	}
}
