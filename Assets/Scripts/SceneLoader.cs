using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadGameScene()
	{
		SceneManager.LoadScene("Game Scene");
	}

	public void LoadGameOverScene()
	{
		SceneManager.LoadScene("Game Over");
	}

	public void LoadStartMenuScene()
	{
		SceneManager.LoadScene("Start Menu");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
