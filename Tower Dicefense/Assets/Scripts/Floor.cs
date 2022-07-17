using UnityEngine;

public class Floor : MonoBehaviour {
    public Transform DiceExit;
    public void start() {

    }
    public void update() {

    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = DiceExit.transform.position;
    }
}