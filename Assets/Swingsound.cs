using UnityEngine;
using System.Collections;

public class Swingsound : MonoBehaviour {
	AudioSource audi;


	// Use this for initialization
	void Start () 
	{
		audi = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			audi.Play ();

		}
	}
}
