using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceEntered : MonoBehaviour
{
    public IDiceTriggerable triggerable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        triggerable.onDiceEntered();
    }
}
