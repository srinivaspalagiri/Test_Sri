using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SoundMixer : MonoBehaviour {
	public AudioMixer masterMix;
	// Use this for initialization
	public void setPitchVolume(float pitchValue)
	{
		masterMix.SetFloat ("heartbeat_pitch",pitchValue);
	}
}
