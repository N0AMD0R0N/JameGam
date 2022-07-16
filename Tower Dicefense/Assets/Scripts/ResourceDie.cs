using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceDie : MonoBehaviour
{
    public int value = 0;
    public List<DieAnchor> anchors;
    public System.Action<int> onValue;
    private Rigidbody rigidbody;   //Get this in Start()
    private bool stopped = false;
    private int DetermineUpSide() {
        return anchors.OrderByDescending(anchor => anchor.transform.position.y).FirstOrDefault().value;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update() {
        if(rigidbody.velocity == Vector3.zero && !stopped) {
            value = DetermineUpSide();
            stopped = true;
            onValue(value);
        }
    }
}
