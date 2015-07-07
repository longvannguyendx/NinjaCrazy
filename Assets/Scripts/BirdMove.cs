using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {

	float speed = 10f;
	GameObject _InGameUIManager;
	InGameUIManager _ingame;
	public GameObject _explosiveEffect;
	//---
	void Awake(){
		// Two
		_InGameUIManager = GameObject.Find ("UIManager");
		_ingame = _InGameUIManager.GetComponent<InGameUIManager>();
		//------
	}

	void Update()
	{
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ())
			return;
		transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy(gameObject);
			Instantiate(_explosiveEffect, transform.position, Quaternion.identity);
			Player.PlayerChangeState("Dead");
			GameManager.SetGameOver(true);
			SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_PLAYER_DEAD);
			//			InGameUIManager.SlideDown("GameOverState");
			
			// One
			//			_instances_InGame.SlideDown("GameOverState");
			//---
			// Two
			_ingame.SlideDown("GameOverState");
			//----
			
		} else if (other.gameObject.tag == "Attack") {
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
	}
}
