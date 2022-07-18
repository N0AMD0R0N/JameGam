using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private Queue<GameObject> hitDice = new Queue<GameObject>();

	// Start is called before the first frame update
	void Start()
    {
		foreach(Transform child in transform) {
            if(child.gameObject.tag == "HitDie") {
                hitDice.Enqueue(child.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision!");
        if(other.transform.tag == "Enemy") {
            if(hitDice.Count > 0) {
                var lastDie = hitDice.Dequeue();
                Destroy(lastDie);
            } else {
                Time.timeScale = 0;
            }
            Debug.Log(hitDice.Count);
        } else {
            Debug.Log("not an enemy?");
        }
    }
}
