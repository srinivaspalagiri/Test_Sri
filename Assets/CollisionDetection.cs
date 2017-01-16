using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
	//GameObject player;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag=="Player")
		{
			PlayerMovement1 myPlayer = (PlayerMovement1)GameObject.Find("Player").GetComponent ("PlayerMovement1");
			//		player = GameObject.FindGameObjectWithTag ("Player");
			//		PlayerMovement1 playerScript = player.GetComponent<PlayerMovement1>();
			//myPlayer.currentCheckpoint=this.transform.position;
		}
	}

}
