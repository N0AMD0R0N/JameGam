using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTower : MonoBehaviour, IDiceTriggerable
{
    public int diceToRoll;
    public GameObject dieModel;
    public GameObject DiceEntry;
    public DiceEntered DiceEntered;
    public GameObject DiceExit;
    private Vector3 throwSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.throwSpeed = new Vector3(20,-20,-30);
        DiceEntered.triggerable = this;
        for(int i = 0; i < diceToRoll; i++) {
            Instantiate(dieModel, DiceEntry.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onDiceEntered() {
        GameObject obj = (GameObject)Instantiate(dieModel, DiceExit.transform.position, Quaternion.identity);;
        obj.GetComponent<Rigidbody>().velocity = this.throwSpeed;
    }
}
