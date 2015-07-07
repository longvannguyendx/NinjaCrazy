using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class NJ_VL_Sound_Manager : MonoBehaviour {

	
	public static int BACKGROUND = 0;
	public static int PLAYER_JUMP = 1;
	public static int PLAYER_SLIDE = 2;
	public static int PLAYER_ATTACK = 3;
	public static int PLAYER_GET_COIN = 4;


	public AudioClip[] _clips;
	[HideInInspector]public AudioSource _audioSound;
	public static NJ_VL_Sound_Manager _instance;
		

		
	void Awake(){
		_instance = GetComponent<NJ_VL_Sound_Manager>();
		_audioSound = this.GetComponent<AudioSource>();
	}
		
	public static void PlaySFX(int i){
		_instance._audioSound.PlayOneShot(_instance._clips[i], 1f);
	}
		
	void Update(){
//		_audioSound.volume = PlayerPrefs.GetFloat("Sound");
	}
}
