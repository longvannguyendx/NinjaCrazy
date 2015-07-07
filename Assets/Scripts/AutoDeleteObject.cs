using UnityEngine;
using System.Collections;

public class AutoDeleteObject : MonoBehaviour {

	InGameUIManager _uiManager = null;

	void Awake()
	{
		GameObject findObject = GameObject.Find ("UIManager");
		if (findObject != null) {
			_uiManager = findObject.GetComponent<InGameUIManager>();
		}

	}
	void OnTriggerEnter2D (Collider2D other)
	{

		bool check = (other.gameObject.tag == "Ground") 
			|| (other.gameObject.tag == "Kunai") 
			|| (other.gameObject.tag == "Ball") 
			|| (other.gameObject.tag == "Bomb")
			|| (other.gameObject.tag == "Coin");

		if (check ){
			Destroy (other.gameObject);
		}
		
		if ((other.gameObject.tag == "Background")){
			other.gameObject.transform.position = new Vector3(5.36f, 0.2751735f, 0);
		}

		if (other.gameObject.tag== "Player"){
			Player.PlayerChangeState("Dead");
			SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_PLAYER_DEAD);
			if (_uiManager != null) {
				_uiManager.SlideDown("GameOverState");
			}

		}
	}
}
