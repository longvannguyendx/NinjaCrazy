using UnityEngine;
using System.Collections;

public class MainMenuUIManager : MonoBehaviour {

	public GameObject _panelExitConfirmState;
	public GameObject _panelAboutState;
	public GameObject _panelSettingState;
	public GameObject _panelHelpState;

	GameObject _currentState = null;
	// Use this for initialization
	void Awake () {
		// Run music background
		/// <summary>
		/// 
		/// </summary>
	}

	void SetCurrentState(string stateName)
	{
		if (stateName == "ExitConfirmState") {
			_currentState = _panelExitConfirmState;
		} else if (stateName == "AboutState") {
			_currentState = _panelAboutState;
		} else if (stateName == "SettingState") {
			_currentState = _panelSettingState;
		} else if (stateName == "HelpState") {
			_currentState = _panelHelpState;
		}
	}
	public void SlideUp(string stateName)
	{

		SetCurrentState (stateName);
		SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_BUTTON);
		if (_currentState != null) {
			iTween.MoveTo (_currentState, new Vector3 (0f, 10.2f, 0f), 0.3f);
		}
	}

	public void SlideDown(string stateName)
	{
		SetCurrentState (stateName);
		SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_BUTTON);
		if (_currentState != null) {
			iTween.MoveTo (_currentState, new Vector3 (0f, 0f, 0f), 0.3f);
		}
	}

	public void StartGame()
	{
		Application.LoadLevel ("InGame");
		SoundManager.GetInstance ().PlaySFX (SoundManager.SOUND_BUTTON);
	}
}
