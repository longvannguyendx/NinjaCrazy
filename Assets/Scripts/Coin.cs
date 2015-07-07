using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	float speed = 10f;
	public GameObject _coinEffect;
	// Use this for initialization
	void Start () {
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
			Instantiate(_coinEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
			GameManager.IncCoin();
			SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_PLAYER_GET_COIN);
		}
	}
}
