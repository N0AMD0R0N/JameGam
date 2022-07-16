using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

	[Header("Attributes")]

	public GameObject projectilePrefab;
	public float range = 10f;
	public float fireRate = 2f;
	public float fireCountdown = 0f;

	[Header("Unity Setup")]

	public Transform targetEnemy = null;
	public Transform towerDiceCenter;
	public Transform rangeTransform;
	public Transform firePoint;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(rangeTransform.position, range);
	}

	// Start is called before the first frame update
	void Start()
    {
		InvokeRepeating("updateTarget", 0f, 0.5f);
    }

	private void updateTarget()
	{
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach(GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(rangeTransform.position, enemy.transform.position);
			if( distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		if(nearestEnemy != null && shortestDistance <= range)
		{
			targetEnemy = nearestEnemy.transform;

		} else
		{
			targetEnemy = null;
		}
	}

	private void shoot()
	{
		Debug.Log("shoot");
	}

	// Update is called once per frame
	void Update()
    {
        if(targetEnemy == null)
		{
			return;
		}
		Vector3 direction = targetEnemy.position - firePoint.transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		Vector3 rotation = lookRotation.eulerAngles;
		firePoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}