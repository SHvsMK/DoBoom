using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour {

	public int textureSize = 1; //power of two
	// Use this for initialization
	void Start () {
		var newWidth = Mathf.Ceil(Screen.width/(textureSize *PixelPerfectCamera.scale));
		var newHeight = Mathf.Ceil(Screen.height/(textureSize *PixelPerfectCamera.scale));

		transform.localScale = new Vector3 (newWidth * textureSize, newHeight * textureSize, 1);

		GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (newWidth, newHeight, 1);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
