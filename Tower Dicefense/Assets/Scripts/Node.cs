using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	private Color startColor;
	private Renderer rend;
	private GameObject tower = null;
	public Vector3 positionOffset;


	private void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	private void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(1) && tower) {
			GameObject.Destroy(tower);
			tower = null;
		} else if (Input.GetMouseButtonDown(0) && !tower) {
			GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
			if(towerToBuild) {
				tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
			}
		}
	}

	private void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	private void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
