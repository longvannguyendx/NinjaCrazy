using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameUIManager : MonoBehaviour {

	public GameObject _panelPause;
	public GameObject _panelGameOver;

	GameObject _currentState = null;

	public Text _coinGameOver;
	public Text _scoreGameOver;
	static InGameUIManager _instance;
	// Use this for initialization
	void Start () {
		_instance = this;
	}

	void SetCurrentState(string stateName)
	{
		if (stateName == "PauseState") {
			_currentState = _panelPause;

		} else if (stateName == "GameOverState") {
			_instance._currentState = _panelGameOver;
			_instance._coinGameOver.text = GameManager.GetCoin().ToString();
			_instance._scoreGameOver.text = GameManager.GetScore().ToString();
		}
	}
	public void SlideUp(string stateName)
	{
		SoundManager.GetInstance().ResumeAllSounds();
		SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_BUTTON);
		GameManager.SetPauseGame (false);

		_instance.SetCurrentState (stateName);
		if (_instance._currentState != null) {
			iTween.MoveTo (_instance._currentState, new Vector3 (0f, 10.2f, 0f), 0.3f);
		}
	}

	public void SlideDown(string stateName)
	{
		GameManager.SetPauseGame (true);
		if (stateName == "PauseState") {
			SoundManager.GetInstance ().PauseAllSounds ();
		} else {
			SoundManager.GetInstance().ResumeAllSounds();
		}

		SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_BUTTON);
		_instance.SetCurrentState (stateName);
		if (_instance._currentState != null) {
			iTween.MoveTo (_instance._currentState, new Vector3 (0f, 0f, 0f), 0.3f);
		}
	}

	public void PlayAgain()
	{
		GameManager.Reset ();
		Application.LoadLevel ("InGame");
		SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_BUTTON);
	}

	public void GoToMainMenu()
	{
		GameManager.Reset ();
		Application.LoadLevel ("MainMenu");
		SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_BUTTON);
	}
}
