using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	public Color hoverColor;
	private Color startColor;
	private Renderer rend;
	private GameObject tower;
	public Vector3 positionOffset;


	private void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	private void OnMouseDown()
	{
		if (tower != null)
		{
			Debug.Log("Node is occupied by a tower, can't build");
			return;
		}
		GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
		tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
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
