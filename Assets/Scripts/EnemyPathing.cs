using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
	WaveConfig waveConfig;
	List<Transform> waypoints;
	int waypointIndex = 0;

	void Start()
	{
	}

	private void Update()
	{
		Move();
	}

	public void SetWaveConfig(WaveConfig waveConfig)
	{
		this.waveConfig = waveConfig;
		waypoints = waveConfig.GetWaypoints();
	}

	private void Move()
	{
		if (waveConfig != null)
		{
			float moveSpeed = waveConfig.GetMoveSpeed();
			if (waypointIndex <= waypoints.Count - 1)
			{
				Vector3 targetPosition = waypoints[waypointIndex].transform.position;
				float movementThisFrame = moveSpeed * Time.deltaTime;
				transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

				if (transform.position == targetPosition)
				{
					waypointIndex++;
				}
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
