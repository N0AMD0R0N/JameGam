﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 10f;
	public Transform enemy;
	private Transform targetWaypoint;
	private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
		targetWaypoint = Waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 direction = targetWaypoint.position - transform.position;
		transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

		if(Vector3.Distance(transform.position, targetWaypoint.position) < 0.2f)
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