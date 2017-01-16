using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class PlayerMovement1 : MonoBehaviour{

	private Vector3 _startPosition;
	ThinkGearController controller;
	public float speed;
	private int Attention;
	private int Meditation;
	private bool noAttention;
	private bool isTouch;
	private bool shiftPressed;
	public bool meditateMode;
	public bool enemyInTerritory;
	public bool playerTriggered;
	public bool MoveEnemy;
	public bool stopPlayer;
	public Vector3 Pos;

	//All GameObject Stuff
	public GameObject player;
	public GameObject enemy;
	public GameObject Level_1;
	//public AudioMixer masterMix;


	//All Audio Stuff
	private float resetHRPitch=1.0f;
	public AudioClip soundCue;
	public AudioSource[] sounds;
	public AudioSource footSteps;
	public AudioSource heartBeat;

	// Use this for initialization
	void Start () {	
		Pos = this.transform.position;
		controller = GameObject.Find ("ThinkGear").GetComponent<ThinkGearController> ();
		controller.UpdateAttentionEvent += OnUpdateAttention;
		controller.UpdateMeditationEvent += OnUpdateMeditation;

		sounds= GetComponents<AudioSource>();

		ResetValues ();
	}

	void OnUpdateAttention(int value){
		Attention = value;
	}
	void OnUpdateMeditation(int value){
		Meditation = value;
	}

	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(MoveEnemy)
		{
			enemy.transform.position+=new Vector3 (-(speed*Time.deltaTime),0,0);
			Destroy (enemy, 15.0f);
		}
		//Vector3 pos_Forward = new Vector3 (0,0,-transform.position.z+movSpeed);
		if (Attention > 40 && footSteps.isPlaying == false && isTouch == false && meditateMode==false) {
			transform.position += Vector3.forward * Attention * Time.deltaTime;
			footSteps.volume = Random.Range (0.3f, 0.5f);
			footSteps.pitch = Random.Range (0.8f, 1.2f);
			footSteps.Play ();
		} 
//		if (isTouch == true && Meditation > 50) {
//			Destroy (enemy);
//		}
		if (stopPlayer) 
		{
			//shiftPressed = true;
			meditateMode = true;
			increHR (Meditation);

		}
		else if (stopPlayer==true && enemyInTerritory == true && Meditation<30) 
		{
			playerTriggered=true;
			PlayerDead (2.0f);
		}
		else 
		{
			meditateMode = false;
			shiftPressed = false;
			heartBeat.volume = 0.0f;
			heartBeat.pitch = resetHRPitch;
		}

	}			

//		public void setPitchVolume(float pitchValue)
//		{
//			masterMix.SetFloat ("heartbeat_pitch",pitchValue);
//		}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Level_1")
		{
			StartCoroutine (PlayerDead(2.0f));	
		}
		if (other.tag == "Obstacle")
		{
			isTouch = true;			
		}
		if (other.tag == "enemy") 
		{
			enemyInTerritory = true;
		}
		if (other.tag == "soundCol") 
		{
			stopPlayer = true;
			MoveEnemy = true;

		}
		if (other.tag == "CheckPoint") 
		{
			Pos = other.transform.position;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "enemy") 
		{	
			Destroy (GameObject.FindGameObjectWithTag("soundCol"));
			enemyInTerritory = false;
			stopPlayer = false;
			MoveEnemy = false;
		}
	}

	void increHR(float med)
	{
		if (meditateMode==true) 
		{
			heartBeat.volume = 1.0f;
			if (med > 40) 
			{
				heartBeat.pitch = 2.0f;
			} else 
			{
				heartBeat.pitch = 1.0f;			}

		}
	}
	void ResetValues()
	{
		noAttention = false;
		shiftPressed = false;
		isTouch = false;
		meditateMode = false;
		MoveEnemy = false;
		stopPlayer = false;
		heartBeat.volume = 0.0f;
		heartBeat.pitch = resetHRPitch;
	}

	IEnumerator PlayerDead(float time)
	{
		yield return new WaitForSeconds(time);
		this.transform.position = Pos;

	}

}