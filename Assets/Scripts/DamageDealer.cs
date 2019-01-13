using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {

	[SerializeField] int damage = 100;
	[SerializeField] bool toEnemy = true;

	public int GetDamage()
	{
		return damage;
	}

	public bool GetDamageIsForEnemy()
	{
		return toEnemy;
	}

	public void Hit()
	{
		Destroy(gameObject);
	}
}
