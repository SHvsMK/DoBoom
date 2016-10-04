using UnityEngine;
using System.Collections;

public class SpecialBoxExplosion : GamePlay {

	private ObjectPos itempos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy () {
		var pos = GetComponent<Transform> ().position;
		itempos.x = pos.x;
		itempos.y = pos.y;
		SpecialBoxList.Remove (itempos);
		GameObject item = (GameObject)Instantiate(prefab [0], pos, Quaternion.identity);
		item.GetComponent<ItemAttribute> ().SetItemNumber (1);
		ItemList [itempos] = item;
		Debug.Log (itempos);
	}
}
