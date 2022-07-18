using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceDie : MonoBehaviour
{
    public int value = 0;
    public List<DieAnchor> anchors;
    public bool stopped = false;
    private Rigidbody dieRigidbody;   //Get this in Start()
    private BoxCollider dieCollider;   //Get this in Start()
    private int DetermineUpSide() {
        return anchors.OrderByDescending(anchor => anchor.anchorTransform.position.y).FirstOrDefault().value;
    }

    // Start is called before the first frame update
    void Start()
    {
        dieRigidbody = this.gameObject.GetComponent<Rigidbody>();
        dieCollider = this.gameObject.GetComponent<BoxCollider>();
    }

    private void Update() {
        if(dieRigidbody.velocity == Vector3.zero && !stopped) {
            value = DetermineUpSide();
            stopped = true;
            dieRigidbody.freezeRotation = true;
        }
    }

}
