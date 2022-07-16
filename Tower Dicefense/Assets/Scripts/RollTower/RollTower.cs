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

    // Start is called before the first frame update
    void Start()
    {
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
        Instantiate(dieModel, DiceExit.transform.position, Quaternion.identity);
    }
}
