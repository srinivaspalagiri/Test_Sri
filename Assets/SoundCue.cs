using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SoundCue : MonoBehaviour {
	public GameObject Player;
	AudioSource audi;
	public AudioClip dank;
	// Use this for initialization
	void Start () {
		audi = GetComponent<AudioSource> ();
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") 
		{
			audi.PlayOneShot (dank,1f);
		}

	}
}
