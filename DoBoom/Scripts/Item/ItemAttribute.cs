using UnityEngine;
using System.Collections;

public class ItemAttribute : GamePlay {

	private int ItemNumber;
	private ObjectPos itempos;

	public int GetItemNumber () {
		return ItemNumber;
	}

	public void SetItemNumber (int number) {
		ItemNumber = number;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ItemNumber == 9 || ItemNumber == 8)
			return;
		Destroy (this.gameObject, ItemDestroyTime);
	}

	void OnDestroy () {
		var pos = GetComponent<Transform> ().position;
		itempos.x = pos.x;
		itempos.y = pos.y;
		ItemList.Remove (itempos);
	}
}
