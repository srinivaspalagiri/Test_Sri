using UnityEngine;
using System.Collections;

public class RatSound : MonoBehaviour {
	public AudioSource audi;

	// Use this for initialization
	void Start () {
		audi = GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			audi.Play ();
			Destroy (this.gameObject,6.0f);
		}
	}
}
