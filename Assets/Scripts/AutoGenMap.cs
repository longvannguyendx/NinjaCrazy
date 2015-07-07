using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AutoGenMap : MonoBehaviour {

	public GameObject _ground;
	public GameObject _ground2;
	public GameObject _background;
	public GameObject _coin1;
	public GameObject _coin2;
	public GameObject _coin3;
	public GameObject _coin4;
	public GameObject _coin5;
	public GameObject _coin6;
	public GameObject _coin7;
	public GameObject _ball;

	public Text _coinPlayer;
	public Text _scorePlayer;
	public GameObject _birdEnemy;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("GenGround", 1F, 1F);
		InvokeRepeating ("GenCoin", 1F, 1F);
		InvokeRepeating ("GenBall", 1F, 3F);
		InvokeRepeating ("IncScore", 0F, 0.1F);
		InvokeRepeating ("GenBirdEnemy", 0F, 5F);
	}


	void GenBirdEnemy()
	{
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ())
			return;
		float x = Random.Range (8f, 15f);
		float y = Random.Range (-0.7f, 1f);
		Instantiate (_birdEnemy, new Vector3 (x, y, 100f), Quaternion.identity);
	}
	void IncScore()
	{
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ())
			return;
		int score = int.Parse (_scorePlayer.text.ToString());
		score++;
		_scorePlayer.text = score.ToString();
		GameManager.SetScore (score);
	}


	void GenBall()
	{
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ())
			return;
		float x = Random.Range (8f, 15f);
		float y = Random.Range (-0.7f, 1f);
		Instantiate (_ball, new Vector3 (x, y, 100f), Quaternion.identity);
	}

	void GenGround()
	{
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ())
			return;
		float x = Random.Range (8f, 15f);
		int indexGround = Random.Range (1, 3);
		GameObject ground = _ground;
		switch (indexGround) {
		case 1: ground = _ground; break;
		case 2: ground = _ground2; break;
		default:
			break;
		}

		// float y = Random.Range (-4, 0);
		Instantiate (ground, new Vector3 (x, -4f, 100f), Quaternion.identity);
	}

	void GenCoin()
	{
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ())
			return;
		float x = Random.Range (8f, 15f);
		float y = Random.Range (-2f, 3f);
		int indexCoin = Random.Range (1, 8);
		GameObject coin = _coin1;
		switch (indexCoin) {
		case 1: coin = _coin1; break;
		case 2: coin = _coin2; break;
		case 3: coin = _coin3; break;
		case 4: coin = _coin4; break;
		case 5: coin = _coin5; break;
		case 6: coin = _coin6; break;
		case 7: coin = _coin7; break;
		default:
			break;
		}
		if (coin != null) {
			Instantiate(coin, new Vector3(x, y,100f), Quaternion.identity);
		}
	}
	// Update is called once per frame
	void Update () {
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ())
			return;
		_coinPlayer.text = GameManager.GetCoin ().ToString ();
	}
}
