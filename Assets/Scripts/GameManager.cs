using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static int _score;
	static int _coin;
	static bool _isPauseGame;
	static bool _isGameOver;

	public static void SetScore(int score)
	{
		_score = score;
	}

	public static void IncCoin(int coin)
	{
		_coin += coin;
	}
	public static void IncCoin()
	{
		_coin++;
	}

	public static void SetCoin(int coin)
	{
		_coin = coin;
	}

	public static int GetCoin()
	{
		return _coin;
	}

	public static int GetScore()
	{
		return _score;
	}

	public static bool IsPauseGame()
	{
		return _isPauseGame;
	}

	public static void SetPauseGame(bool isPause)
	{
		_isPauseGame = isPause;
	}

	public static bool IsGameOver()
	{
		return _isGameOver;
	}
	
	public static void SetGameOver(bool iGameOver)
	{
		_isGameOver = iGameOver;
	}

	public static void Reset()
	{
		GameManager.SetGameOver (false);
		GameManager.SetPauseGame (false);
		GameManager.SetCoin (0);
		GameManager.SetScore (0);
	}

}
