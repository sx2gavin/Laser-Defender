using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

	[SerializeField] int gameScore = 0;

	private void Awake()
	{
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(this.gameObject);
		}
		else
		{
			DontDestroyOnLoad(this.gameObject);
		}
	}

	public void AddScore(int score)
	{
		gameScore += score;
	}

	public int GetScore()
	{
		return gameScore;
	}

	public void ResetGameSession()
	{
		// gameScore = 0;
		Destroy(gameObject);
	}
}
