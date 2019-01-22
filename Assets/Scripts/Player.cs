using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// configuration parameters

	[Header("Player")]
	[SerializeField] float speed;
	[SerializeField] GameObject laserPrefab;
	[SerializeField] float health = 1000f;
	[SerializeField] [Range(0, 1)] float deathSoundVolume = 1f;
	[SerializeField] AudioClip deathSound;

	[Header("Projectile")]
	[SerializeField] float projectileSpeed = 10f;
	[SerializeField] float projectileFiringPeriod = 0.1f;
	[SerializeField][Range(0, 1)] float fireLaserVolume = 1f;
	[SerializeField] AudioClip fireLaserSound;



	Coroutine firingCoroutine;

	float xMin;
	float xMax;
	float yMin;
	float yMax;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		SetUpMoveBoundaries();
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		Fire();
	}

	private void Fire()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			firingCoroutine = StartCoroutine(FireContinuously());
		}
		else if (Input.GetButtonUp("Fire1"))
		{
			StopCoroutine(firingCoroutine);
		}
	}

	private IEnumerator FireContinuously()
	{
		while (true)
		{
			GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
			AudioSource.PlayClipAtPoint(fireLaserSound, transform.position, fireLaserVolume);
			laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
			yield return new WaitForSeconds(projectileFiringPeriod);
		}
	}

	private void SetUpMoveBoundaries()
	{
		float halfWidthOfSprite = spriteRenderer.size.x / 2;
		float halfHeightOfSprite = spriteRenderer.size.y / 2;
		Camera gameCamera = Camera.main;
		xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + halfWidthOfSprite;
		xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - halfWidthOfSprite;
		yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + halfHeightOfSprite;
		yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - halfHeightOfSprite;
	}

	private void Move()
	{
		var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
		var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

		transform.position = new Vector3(newXPos, newYPos, transform.position.z);
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
		Destroy(gameObject);
		AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
		SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
		if (sceneLoader != null)
		{
			sceneLoader.LoadGameOverScene();
		}
	}
}
