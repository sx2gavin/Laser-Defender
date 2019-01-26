using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[Header("Attributes")]
	[SerializeField] float health = 200f;
	[SerializeField] int pointsUponDeath = 100;
	float shotCounter;
	[SerializeField] float minTimeBetweenShots = 0.2f;
	[SerializeField] float maxTimeBetweenShots = 3f;
	[SerializeField] GameObject laserPrefab;
	[SerializeField] float projectileSpeed = 1f;

	[Header("Sounds")]
	[SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
	[SerializeField] AudioClip deathSound;
	[SerializeField] [Range(0, 1)] float fireLaserVolume = 0.25f;
	[SerializeField] AudioClip fireLaserSound;

	// Cached objects
	GameSession gameSession;

	// Use this for initialization
	void Start () {
		shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		gameSession = FindObjectOfType<GameSession>();
	}
	
	// Update is called once per frame
	void Update () {
		CountDownAndShoot();
	}

	private void CountDownAndShoot()
	{
		shotCounter -= Time.deltaTime;
		if (shotCounter <= 0f)
		{
			Fire();
			shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		}
	}

	private void Fire()
	{
		GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(fireLaserSound, transform.position, fireLaserVolume);
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		DamageDealer damageDealer = other.GetComponent<DamageDealer>();
		ProcessHit(damageDealer);
	}

	private void ProcessHit(DamageDealer damageDealer)
	{
		if (damageDealer != null)
		{
			health -= damageDealer.GetDamage();
			damageDealer.Hit();
		}

		if (health <= 0) 
		{
			Die();
		}
	}

	private void Die()
	{
		if (gameSession != null)
		{
			gameSession.AddScore(pointsUponDeath);
		}
		Destroy(gameObject);
		AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
	}
}
