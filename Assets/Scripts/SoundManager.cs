using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	private static SoundManager _instance;

	[HideInInspector] public static int SOUND_BUTTON = 0;
	[HideInInspector] public static int SOUND_BACKGROUND_MAINMENU = 1;
	[HideInInspector] public static int SOUND_BACKGROUND_INGAME = 2;
	[HideInInspector] public static int SOUND_PLAYER_JUMP = 3;
	[HideInInspector] public static int SOUND_PLAYER_SLIDE = 4;
	[HideInInspector] public static int SOUND_PLAYER_ATTACK = 5;
	[HideInInspector] public static int SOUND_PLAYER_GET_COIN = 6;
	[HideInInspector] public static int SOUND_PLAYER_DEAD = 7;


	public AudioClip[] _clips;
	[HideInInspector]public AudioSource _audioSound;

	public static SoundManager GetInstance()
	{
		if (_instance == null) {
			_instance = GameObject.FindObjectOfType<SoundManager>();
		}
		return _instance;
	}
	void Awake() 
	{
		_instance = this;
		_audioSound = GetComponent<AudioSource> ();
	}
	
	public void PlaySFX(int i){
		_instance._audioSound.PlayOneShot(_instance._clips[i], 1f);
	}

	public void StopSFX()
	{
		if (_instance._audioSound.isPlaying) {
			_instance._audioSound.Stop();
		}
	}

	public void PauseAllSounds()
	{
		AudioListener.pause = true;
	}

	public void ResumeAllSounds()
	{
		AudioListener.pause = false;
	}

	public void StopAllSound()
	{

	}
	// Update is called once per frame
	void Update () {
	
	}
}
