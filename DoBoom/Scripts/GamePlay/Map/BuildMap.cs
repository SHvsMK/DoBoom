using UnityEngine;
using System.Collections;

public class BuildMap : DoBoom {

	private GameObject floor;

	// Use this for initialization
	void Start () {
		floor = (GameObject)Instantiate (prefab [0]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
