using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	[SerializeField] float delayInSeconds = 2f;

	public void LoadGameScene()
	{
		SceneManager.LoadScene("Game Scene");
	}

	public void LoadGameOverScene()
	{
		StartCoroutine(DelayedGameOver());
	}

	private IEnumerator DelayedGameOver()
	{
		yield return new WaitForSeconds(delayInSeconds);
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
