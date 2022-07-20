using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;
	public TowerCollection[] towerCollections;
	public ResourceManager resourceManager;

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
		foreach(TowerCollection collection in  towerCollections)
		{
			collection.OnSelect = onSelection;
		}
		towerToBuild = standardTowerToBuildPrefab;
	}

	private GameObject towerToBuild;
	// Start is called before the first frame update

	public GameObject GetTowerToBuild()
	{
		var gold = towerToBuild.GetComponent<Purchasable>().Gold;
		var gems = towerToBuild.GetComponent<Purchasable>().Gems;
		var mana = towerToBuild.GetComponent<Purchasable>().Mana;
		if(resourceManager.spendResources(gold, gems, mana)) {
			return towerToBuild; 
		}
		return null;
	}

	private void onSelection(TowerCollection selectedCollection) {
		foreach(TowerCollection collection in  towerCollections)
		{
			collection.selected = false;
		}
		selectedCollection.selected = true;
		towerToBuild = selectedCollection.tower;
	}
}
