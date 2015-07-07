using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject _kunai;
	public GameObject _attack;

	Animator _anin;
	Rigidbody2D _rigidbody;
	float _maxJumpHigh = 800f;

	int MAX_NUMBER_JUMP = 2;
	int _currentNumberJump = 0;

	static Player _instance;
	// Use this for initialization
	void Start () {
		_instance = this;
		_anin = GetComponent<Animator> ();
		_rigidbody = GetComponent<Rigidbody2D> ();


	}

	public static string GetStatusPlayer()
	{
		if (_instance._anin.GetCurrentAnimatorStateInfo (0).IsName ("Run"))
			return "Run";
		if (_instance._anin.GetCurrentAnimatorStateInfo (0).IsName ("Attack"))
			return "Attack";
		if (_instance._anin.GetCurrentAnimatorStateInfo (0).IsName ("Slide"))
			return "Slide";
		if (_instance._anin.GetCurrentAnimatorStateInfo (0).IsName ("Jump"))
			return "Jump";
		if (_instance._anin.GetCurrentAnimatorStateInfo (0).IsName ("Dead"))
			return "Dead";
		return "";
	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Space)) {
			PlayerAttack ();
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			PlayerJump ();
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			PlayerSlide ();
		}

		if (true) {
	
		}
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ()) {
			_rigidbody.gravityScale = 0;
			return;
		} else {
			_rigidbody.gravityScale = 4;
		}
			

	}

	public void PlayerAttack()
	{
		if (GetStatusPlayer () == "Dead")
			return;
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ())
			return;
		SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_PLAYER_ATTACK);
		PlayerChangeState ("Attack");
		Instantiate (_attack, gameObject.transform.position, _attack.transform.rotation);
	}

	public static void PlayerChangeState(string state)
	{
		_instance._anin.CrossFade (state, 0f);
	}

	public static void ResetNumberJumpPlayer()
	{
		_instance._currentNumberJump = 0;
	}

	public void PlayerJump()
	{
		if (GetStatusPlayer () == "Dead")
			return;
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ())
			return;
		if (_currentNumberJump >= MAX_NUMBER_JUMP)
			return;
		SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_PLAYER_JUMP);
		PlayerChangeState ("Jump");
		_rigidbody.velocity = Vector2.zero;
		_rigidbody.AddForce (new Vector2(0, _maxJumpHigh));
		_currentNumberJump++;
	}

	public void PlayerSlide()
	{
		if (GetStatusPlayer () == "Dead")
			return;
		if (GameManager.IsGameOver () || GameManager.IsPauseGame ())
			return;
		SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_PLAYER_SLIDE);
		PlayerChangeState ("Slide");
		_rigidbody.velocity = Vector2.zero;
		_rigidbody.AddForce (new Vector2(0, -_maxJumpHigh));
		// _rigidbody.AddForce (new Vector2(0, _maxJumpHigh));
	}
}
