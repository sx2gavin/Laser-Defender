using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour {

	// Cached objects
	TextMeshProUGUI textComponent;
	GameSession gameSession;

	// Use this for initialization
	void Start () {
		gameSession = FindObjectOfType<GameSession>();
		textComponent = GetComponent<TextMeshProUGUI>();
		textComponent.text = gameSession.GetScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		textComponent.text = gameSession.GetScore().ToString();
	}
}
