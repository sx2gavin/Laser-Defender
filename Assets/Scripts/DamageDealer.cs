using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

	[SerializeField] int damage = 100;
	[SerializeField] GameObject explosionEffect;

	public int GetDamage()
	{
		return damage;
	}

	public void Hit()
	{
		Explosion();
		Destroy(gameObject);
	}

	private void Explosion()
	{
		GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
		Destroy(explosion, 1);
	}
}
