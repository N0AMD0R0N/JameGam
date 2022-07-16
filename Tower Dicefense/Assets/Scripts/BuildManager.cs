using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
		}
		instance = this;
	}

	public GameObject standardTowerToBuildPrefab;

	private void Start()
	{
		towerToBuild = standardTowerToBuildPrefab;
	}

	private GameObject towerToBuild;
	// Start is called before the first frame update

	public GameObject GetTowerToBuild()
	{
		return towerToBuild; 
	}
}
