using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour, IDefeatable
{
    private Queue<GameObject> hitDice = new Queue<GameObject>();
    private Action lose;

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
        if(other.transform.tag == "Enemy") {
            if(hitDice.Count > 1) {
                loseADie();
            } else {
                loseADie();
                onDefeat(null);
            }
        }
    }

    private void loseADie() {
        var lastDie = hitDice.Dequeue();
        Destroy(lastDie);
    }

    public void onDefeat(Action defeat) {
        if(defeat != null) {
            lose = defeat;
        } else {
            lose();
        }
    }
}
