using UnityEngine;
using System.Collections;

public class BaseAttribute : GamePlay {

	private int BaseHealth;
	private int BaseNumber;
	private bool SuperPowerTime;
	private int startSuperPowerTime;
	private int endSuperPowerTime;
	private ObjectPos[] BaseHealthPresent;
	private Color initialColor;

	// Use this for initialization
	void Start () {
		SuperPowerTime = false;
		//initialColor = GetComponent<SpriteRenderer> ().color;
	}

	public void SetBaseHealthPresent () {
		int flag = 1;
		if (BaseNumber == 1) {
			flag = -1;
		}
		BaseHealthPresent = new ObjectPos[17];
		for (var i = -8; i <= 8; i++) {
			BaseHealthPresent [i + 8].x = i;
			BaseHealthPresent [i + 8].y = 8 * flag;
		}
	}

	public void SetBaseNumber (int number) {
		BaseNumber = number;
	}

	public int GetBaseNumber () {
		return BaseNumber;
	}

	public void SetBaseHealth () {
		BaseHealth = 5;
	}

	public int GetBaseHealth () {
		return BaseHealth;
	}

	private void ChangeHealthPresent () {
		if (BaseNumber == 0) {
			int s = 5 - BaseHealth;
			int e = 5 - BaseHealth + 1;
			if (s == 4) {
				IceList [BaseHealthPresent [0]].GetComponent<SpriteRenderer> ().color = Color.red;
				return;
			}
			for (var i = s * 4; i < e * 4; i++) {
				IceList [BaseHealthPresent [16 - i]].GetComponent<SpriteRenderer> ().color = Color.red;
			}
		} else {
			int s = 5 - BaseHealth;
			int e = 5 - BaseHealth + 1;
			if (s == 4) {
				IceList [BaseHealthPresent [16]].GetComponent<SpriteRenderer> ().color = Color.red;
				return;
			}
			for (var i = s * 4; i < e * 4; i++) {
				IceList [BaseHealthPresent [i]].GetComponent<SpriteRenderer> ().color = Color.red;
			} 
		}
	}

	public void DamageBase () {
		if (SuperPowerTime)
			return;
		if (BaseHealth > 0) {
			ChangeHealthPresent ();
			BaseHealth--;
		}
		startSuperPowerTime = System.DateTime.Now.Second;
		endSuperPowerTime = startSuperPowerTime;
		SuperPowerTime = true;
	}
	// Update is called once per frame
	void Update () {
//		if (SuperPowerTime) {
//			var color = GetComponent<SpriteRenderer> ().color;
//			if (color == initialColor)
//				GetComponent<SpriteRenderer> ().color = Color.yellow;
//			else
//				GetComponent<SpriteRenderer> ().color = initialColor;
//		}
		endSuperPowerTime = System.DateTime.Now.Second;
		if (endSuperPowerTime < startSuperPowerTime)
			endSuperPowerTime += 60;
		if (endSuperPowerTime - startSuperPowerTime > 4)
			SuperPowerTime = false;
		if (BaseHealth == 0) {
			baseLive [BaseNumber] = false;
			Destroy (gameObject);
			GameOver = true;
			if (BaseNumber == 0) {
				Winner = 1;
			} else {
				Winner = 2;
			}
		}
	}
}
