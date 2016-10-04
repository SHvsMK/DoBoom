using UnityEngine;
using System.Collections;

public class Flame : GamePlay {
	private AudioSource source;
	public AudioClip bomb_explosion;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (bomb_explosion, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, 0.5f);
	}
}
