using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] float speed;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move();
	}

	private void Move()
	{
		var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		var newXPos = transform.position.x + deltaX;

		var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		var newYPos = transform.position.y + deltaY;
		transform.position = new Vector3(newXPos, newYPos, transform.position.z);
	}
}
