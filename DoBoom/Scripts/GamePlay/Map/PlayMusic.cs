using UnityEngine;
using System.Collections;
//using UnityEngine.Audio;

public class PlayMusic : MonoBehaviour {


//	public AudioMixerSnapshot outOfCombat;
//	public AudioMixerSnapshot inCombat;
//	public AudioClip[] stings;
	public AudioSource musicSource;
	public AudioClip backMusic;
//	public float bpm = 128;


//	private float m_TransitionIn;
//	private float m_TransitionOut;
//	private float m_QuarterNote;

	// Use this for initialization
	void Start () 
	{
		musicSource.enabled = true;
		musicSource = GetComponent<AudioSource> ();
		musicSource.Play ();
//		m_QuarterNote = 60 / bpm;
//		m_TransitionIn = m_QuarterNote;
//		m_TransitionOut = m_QuarterNote * 32;


	}

//	void OnTriggerEnter(Collider other)
//	{
//		if (other.CompareTag("CombatZone"))
//		{
//			inCombat.TransitionTo(m_TransitionIn);
//			PlaySting();
//		}
//	}
//
//	void OnTriggerExit(Collider other)
//	{
//		if (other.CompareTag("CombatZone"))
//		{
//			outOfCombat.TransitionTo(m_TransitionOut);
//		}
//	}
//
//	void PlaySting()
//	{
//		int randClip = Random.Range (0, stings.Length);
//		stingSource.clip = stings[randClip];
//		stingSource.Play();
//	}


}
