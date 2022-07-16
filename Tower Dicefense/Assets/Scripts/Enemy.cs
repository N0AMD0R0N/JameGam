using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 10f;
	public Transform enemy;
	private Transform targetWaypoint;
	private int waypointIndex = 0;
	public Vector3 facingDirection;
	public Quaternion lookRotation;

    // Start is called before the first frame update
    void Start()
    {
		targetWaypoint = Waypoints.waypoints[0];
		facingDirection = (targetWaypoint.position - transform.position).normalized;
		lookRotation = Quaternion.LookRotation(facingDirection);
		transform.Rotate(0f, 0f, 0f); //  = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 direction = targetWaypoint.position - transform.position;
		transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

		facingDirection = (targetWaypoint.position - transform.position).normalized;
		lookRotation = Quaternion.LookRotation(facingDirection);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

		if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.2f)
		{
			nextWaypointOrDestroy();
		}
    }

	private void nextWaypointOrDestroy()
	{
		if (waypointIndex >= Waypoints.waypoints.Length - 1)
		{
			Destroy(gameObject);
			return;
		}
		waypointIndex++;
		targetWaypoint = Waypoints.waypoints[waypointIndex];
	}
}
