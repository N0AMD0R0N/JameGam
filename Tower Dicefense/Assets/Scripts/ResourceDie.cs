using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDie : MonoBehaviour
{
    
    public int value = 0;
    private Rigidbody rigidbody;   //Get this in Start()
    private int DetermineUpSide() {
        //This method will return 1 .. 6 unless the side can not be determined, in which case it returns 0
        
        return 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update() {
        if(rigidbody.velocity == Vector3.zero) {
            value = DetermineUpSide();
            if(value == 0) {
                    rigidbody.AddForce(new Vector3(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f)), ForceMode.Impulse);
            }
        }
    }
}
