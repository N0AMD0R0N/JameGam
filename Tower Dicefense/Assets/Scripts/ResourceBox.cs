using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceBox : MonoBehaviour
{
    public TMP_Text counter;
    public int value;
    private float counterDelay = 300f;
    
    // Start is called before the first frame update
    void Start()
    {
        counter.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = value.ToString();
        if(counterDelay > 0) {
            counterDelay -= 1;
        } else if (!counter.gameObject.GetComponent<MeshRenderer>().enabled) {
            counter.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    //Upon collision with another GameObject
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "ResourceDie") {
            value += other.gameObject.GetComponent<ResourceDie>().value;
            Destroy(other.gameObject);
        }
    }
}
