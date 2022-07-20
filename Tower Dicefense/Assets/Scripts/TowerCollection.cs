using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCollection : MonoBehaviour
{
	public GameObject selectionMark;
    public GameObject tower;
    public System.Action<TowerCollection> OnSelect;
    public bool selected = false;
    private void Start()
	{
		selectionMark.SetActive(false);
	}

    private void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0)) {
            Debug.Log("AAAAAAh!!!");
            if(selected) {
                selected = false;
            } else {
                selected = true;
                OnSelect(this);
            }
		}
	}

    public void Update()
    {
        selectionMark.SetActive(selected);
    }
}