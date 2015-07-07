using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	float speed = 10f;
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
		if (other.gameObject.tag == "CheckGround") {
			Player.ResetNumberJumpPlayer();
			if (Player.GetStatusPlayer() == "Slide" || Player.GetStatusPlayer() == "Dead") 
				return;
			Player.PlayerChangeState("Run");
		}
	}
}
