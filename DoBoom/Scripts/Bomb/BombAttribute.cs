using UnityEngine;
using System.Collections;

public class BombAttribute : GamePlay {

	private int range;
	private int BelongToPlayer;
	private ObjectPos bombPos;

	public void SetBelongToPlayer (int number) {
		BelongToPlayer = number;
	}

	public int GetBelongToPlayer () {
		return BelongToPlayer;
	}

	public void SetRange (int Range) {
		range = Range;
	}

	public int GetRange () {
		return range;
	}

	void OnCollisionEnter2D (Collision2D col) {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bombPos.x = GetComponent<Transform> ().position.x;
		bombPos.y = GetComponent<Transform> ().position.y;

	}
}
