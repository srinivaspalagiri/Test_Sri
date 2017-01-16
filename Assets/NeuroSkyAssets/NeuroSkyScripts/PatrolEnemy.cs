using UnityEngine;
using System.Collections;
using System;

public class PatrolEnemy : MonoBehaviour{
	GameObject player;
	public float speed = 3f;
	public Vector3 _startPos;
	//public bool playerInTerritory;
	//public bool EnemySound;
	public AudioSource audi;


	void Start ()
	{	
		//EnemySound = false;
		audi = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update ()
	{					
			

//		if (playerInTerritory == false && attackCheck==false) 
//		{
//			transform.Translate (target.position*speed*Time.deltaTime);
//		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			audi.Play ();
		}
	}


//	void OnTriggerEnter (Collider col)
//	{
//		if (col.gameObject == player) 
//		{
//			playerInTerritory = true;
//		}
//	}
//	void OnTriggerExit(Collider col)
//	{
//		playerInTerritory = false;
//	}

}
