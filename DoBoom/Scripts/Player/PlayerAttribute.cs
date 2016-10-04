using UnityEngine;
using System.Collections;

public class PlayerAttribute : GamePlay {

	private int NumberOfBombs;
	private int LeftBombNumber;
	private int RangeOfBomb;
	private float Speed;
	private int TimeOfReborn;
	private int SuperTime;
	private int playerNum;
	private int NumberOfStars;
	private int SpecialObject;
	private string triger;
	private int SuperTimeStart;
	private int SuperTimeEnd;
	private bool Reverse;
	private int ReverseStartTime;
	private int ReverseEndTime;
	private bool SpeedPower;
	private string tick;
	private Color initialColor;
	private bool[] CreateFlag;
	private int[] CreateStartTime;
	private int[] CreateEndTime;
	private int intervalTime = 2;

	public struct Direction {
		public string Up;
		public string Down;
		public string Left;
		public string Right;
		public string place;
	}
	private Direction playerDirection;

	public void InitialCreateFlag () {
		CreateStartTime = new int[6];
		CreateEndTime = new int[6];
		CreateFlag = new bool[6];
		for (var i = 0; i < 6; i++)
			CreateFlag [i] = false;
		for (var i = 0; i < 6; i++) {
			CreateStartTime [i] = System.DateTime.Now.Second;
			CreateEndTime [i] = CreateStartTime [i];
		}
	}

	public void SetCreateFlag (int i) {
		CreateFlag [i] = true;
		CreateStartTime [i] = System.DateTime.Now.Second;
	}

	public bool GetCreateFlag (int i) {
		return CreateFlag [i];
	}

	public void SetSpeedPower (bool power) {
		SpeedPower = power;
	}

	public bool GetSpeedPower () {
		return SpeedPower;
	}

	public void SetReverse (bool reverse) {
		Reverse = reverse;
		if (reverse) {
			ReverseStartTime = System.DateTime.Now.Second;
			ReverseEndTime = ReverseStartTime;
		}
	}

	public bool GetReverse () {
		return Reverse;
	}

	public void SetSuperTime () {
		SuperTime = 3;
		SuperTimeStart = System.DateTime.Now.Second;
		SuperTimeEnd = SuperTimeStart;
	}

	public int GetSuperTime () {
		return SuperTime;
	}

	public void SetTriger () {
		triger = playersControl [playerNum].triger;
	}

	public string GetTriger () {
		return triger;
	}

	private string[] createButton;

	public void SetCreateObject () {
		createButton = new string[6];
		createButton [0] = playersControl [playerNum].createObject [0];
		createButton [1] = playersControl [playerNum].createObject [1];
		createButton [2] = playersControl [playerNum].createObject [2];
		createButton [3] = playersControl [playerNum].createObject [3];
		createButton [4] = playersControl [playerNum].createObject [4];
		createButton [5] = playersControl [playerNum].createObject [5];
	}

	public void SetTick () {
		tick = playersControl [playerNum].tick;
	}

	public string GetTick () {
		return tick;
	}

	public string[] GetCreateObject () {
		return createButton;
	}

	public void InitialSpecialObject () {
		SpecialObject = 1;
	}

	public void SetSpecialObject (int number) {
		SpecialObject = number;
	}

	public int GetSpecialObject () {
		return SpecialObject;
	}

	public void SetNumberOfStars(int number) {
		NumberOfStars = number;
	}

	public int GetNumberOfStars () {
		return NumberOfStars;
	}

	public void SetLeftBombNumber (int number) {
		LeftBombNumber = number;
	}

	public int GetLeftBombNumber () {
		return LeftBombNumber;
	}

	public string GetPlaceBoom () {
		return playerDirection.place;
	}

	public void SetplayerNum (int number) {
		playerNum = number;
	}

	public int GetplayerNum () {
		return playerNum;
	}

	public Direction GetDirection() {
		return playerDirection;
	}

	public void SetNumberOfBombs (int number) {
		NumberOfBombs = number;
	}

	public int GetNumberOfBombs () {
		return NumberOfBombs;
	}

	public void SetRangeOfBomb (int range) {
		RangeOfBomb = range;
	}

	public int GetRangeOfBomb () {
		return RangeOfBomb;
	}

	public void SetSpeed (float speed) {
		Speed = speed;
	}

	public float GetSpeed () {
		return Speed;
	}

	public void SetTimeOfReborn (int time) {
		TimeOfReborn = time;
	}

	public int GetTimeOfReborn () {
		return TimeOfReborn;
	}

	public void SetDirection() {
		playerDirection.Up = playersControl[playerNum].Up;
		playerDirection.Down = playersControl[playerNum].Down;
		playerDirection.Left = playersControl[playerNum].Left;
		playerDirection.Right = playersControl[playerNum].Right;
		playerDirection.place = playersControl[playerNum].place;
	}

	/*void Awake () {
		NumberOfBombs = 1;
		RangeOfBomb = 1;
		Speed = 1;
		TimeOfReborn = 1;
	}*/

	public void SetInitialColor () {
		initialColor = GetComponent<SpriteRenderer> ().color;
	}

	// Use this for initialization
	void Start() {
		initialColor = GetComponent<SpriteRenderer> ().color;
	}

	// Update is called once per frame
	void Update () {
		if (GameOver)
			return;
		//Debug.Log (GetComponent<SpriteRenderer> ().color);
		for (var i = 0; i < 6; i++) {
			if (CreateFlag [i]) {
				CreateEndTime [i] = System.DateTime.Now.Second;
				if (CreateEndTime [i] < CreateStartTime [i])
					CreateEndTime [i] += 60;
				if (CreateEndTime [i] - CreateStartTime [i] > intervalTime)
					CreateFlag [i] = false;
			}
		}
		if (Reverse) {
			var curColor = GetComponent<SpriteRenderer> ().color;
			if (curColor == initialColor)
				GetComponent<SpriteRenderer> ().color = Color.red;
			else
				GetComponent<SpriteRenderer> ().color = initialColor;
		}
		if (SuperTime != 0) {
			var curColor = GetComponent<SpriteRenderer> ().color;
			if (curColor == initialColor)
				GetComponent<SpriteRenderer> ().color = Color.yellow;
			else
				GetComponent<SpriteRenderer> ().color = initialColor;
			SuperTimeEnd = System.DateTime.Now.Second;
			if (SuperTimeEnd < SuperTimeStart) {
				SuperTimeEnd += 60;
			}
			if (SuperTimeEnd - SuperTimeStart >= SuperTime) {
				SuperTime = 0;
			}
		}
		if (!Reverse && SuperTime == 0)
			GetComponent<SpriteRenderer> ().color = initialColor;
		if (Reverse) {
			ReverseEndTime = System.DateTime.Now.Second;
			if (ReverseEndTime < ReverseStartTime) {
				ReverseEndTime += 60;
			}
			if (ReverseEndTime - ReverseStartTime >= 6) {
				Reverse = false;
			}
		}
	}
}
