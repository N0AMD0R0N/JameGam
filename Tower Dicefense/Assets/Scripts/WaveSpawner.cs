﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	// public Transform wavedice;
	public Transform enemy;
	public Transform spawnPoint;
	public Text waveCountdownText;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;
	private int waveIndex = 1;

	// Update is called once per frame
	void Update()
    {
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
		}
		countdown -= Time.deltaTime;
		waveCountdownText.text = Mathf.Round(countdown).ToString();
	}
	private IEnumerator SpawnWave()
	{
		// waveIndex++;

		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
	}

	private void SpawnEnemy()
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}
}