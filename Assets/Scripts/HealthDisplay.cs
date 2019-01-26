using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour {

	// Cached objects
	TextMeshProUGUI textComponent;
	Player player;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<Player>();
		textComponent = GetComponent<TextMeshProUGUI>();
		textComponent.text = player.GetHealth().ToString();
	}

	// Update is called once per frame
	void Update()
	{
		textComponent.text = player.GetHealth().ToString();
	}
}
