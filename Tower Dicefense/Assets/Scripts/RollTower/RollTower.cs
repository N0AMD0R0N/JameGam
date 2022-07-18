using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTower : MonoBehaviour, IDiceTriggerable
{
    public int diceToRoll;
    public ResourceDie dieModel;
    public GameObject DiceEntry;
    public DiceEntered DiceEntered;
    public GameObject DiceExit;
    private Vector3 throwSpeed;
    private System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        this.throwSpeed = new Vector3(20,-20,-30);
        DiceEntered.triggerable = this;
        rollResources();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onDiceEntered() {
        var rotation = Quaternion.Euler (rnd.Next(0,360), rnd.Next(0,360), rnd.Next(0,360));
        ResourceDie die = (ResourceDie)Instantiate(dieModel, DiceExit.transform.position, Quaternion.identity * rotation);
        die.GetComponent<Rigidbody>().velocity = this.throwSpeed;
    }

    public void rollResources() {
        for(int i = 0; i < diceToRoll; i++) {
            ResourceDie die = (ResourceDie)Instantiate(dieModel, DiceEntry.transform.position, Quaternion.identity);
        }
    }
    
}
