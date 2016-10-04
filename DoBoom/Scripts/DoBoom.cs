using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DoBoom : MonoBehaviour {

	public float ItemDestroyTime = 10;
	protected static bool GameOver = false;
	protected static int Winner;

	public struct ObjectPos {
		public float x;
		public float y;
	}

	public struct PlayerControl {
		public string Up;
		public string Down;
		public string Left;
		public string Right;
		public string place;
		public string[] createObject;
		public string triger;
		public string tick;
	}

	public GameObject[] prefab;
	public static GameObject[] playerList;
	public static GameObject[] Bases;

	private ObjectPos RandomPlace;
	protected static Dictionary<ObjectPos, GameObject> BombList;
	protected static Dictionary<ObjectPos, GameObject> ItemList;
	protected static Dictionary<ObjectPos, GameObject> WoodBoxList;
	protected static Dictionary<ObjectPos, GameObject> ObstacleList;
	protected static Dictionary<ObjectPos, GameObject> SpecialBoxList;
	protected static Dictionary<ObjectPos, GameObject> SolidBoxList;
	protected static Dictionary<ObjectPos, GameObject> IceList;
	protected static Dictionary<ObjectPos, GameObject> PitfulList;
	protected static Dictionary<ObjectPos, GameObject> BaseList;
	protected static Dictionary<ObjectPos, bool> SpecialPointList;
	protected static bool[] playerLive;
	protected static bool[] baseLive;
	protected static bool GameStart;
	private GameObject floor;
	private ObjectPos[] playerPos;

	protected static int[] PlayerStartTime;
	protected static int[] PlayerEndTime;
	public static PlayerControl[] playersControl;
	public static int[] trigerTime;

	// Use this for initialization
	void Start () {
		playersControl = new PlayerControl[2];
		playersControl [0].Up = "W";
		playersControl [0].Down = "S";
		playersControl [0].Left = "A";
		playersControl [0].Right = "D";
		playersControl [0].place = "Tab";
		playersControl [0].createObject = new string[6];
		playersControl [0].createObject [0] = "Alpha1";
		playersControl [0].createObject [1] = "Alpha2";
		playersControl [0].createObject [2] = "Alpha3";
		playersControl [0].createObject [3] = "Alpha4";
		playersControl [0].createObject [4] = "Alpha5";
		playersControl [0].createObject [5] = "Alpha6";
		playersControl [0].triger = "LeftShift";
		playersControl [0].tick = "Q";
		playersControl [1].Up = "UpArrow";
		playersControl [1].Down = "DownArrow";
		playersControl [1].Left = "LeftArrow";
		playersControl [1].Right = "RightArrow";
		playersControl [1].place = "Space";
		playersControl [1].createObject = new string[6];
		playersControl [1].createObject [0] = "F";
		playersControl [1].createObject [1] = "G";
		playersControl [1].createObject [2] = "H";
		playersControl [1].createObject [3] = "J";
		playersControl [1].createObject [4] = "K";
		playersControl [1].createObject [5] = "L";
		playersControl [1].triger = "Return";
		playersControl [1].tick = "RightShift";
		trigerTime = new int[2];
		for (var i = 0; i < 2; i++) {
			trigerTime [i] = 1;
		}
		playerLive = new bool[4];
		baseLive = new bool[2];
		BombList = new Dictionary<ObjectPos, GameObject> ();
		ItemList = new Dictionary<ObjectPos, GameObject> ();
		WoodBoxList = new Dictionary<ObjectPos, GameObject> ();
		ObstacleList = new Dictionary<ObjectPos, GameObject> ();
		SpecialBoxList = new Dictionary<ObjectPos, GameObject> ();
		SolidBoxList = new Dictionary<ObjectPos, GameObject> ();
		IceList = new Dictionary<ObjectPos, GameObject> ();
		PitfulList = new Dictionary<ObjectPos, GameObject> ();
		BaseList = new Dictionary<ObjectPos, GameObject> ();
		SpecialPointList = new Dictionary<ObjectPos, bool> ();

		playerList = new GameObject[4];
		Bases = new GameObject[2];
		for (var i = 0; i < 4; i++) {
			playerLive [i] = false;
		}
		GameStart = false;
		SceneManager.LoadScene ("Menu");
	}

	// Update is called once per frame
	void Update () {

	}
}
