using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitToScreen : MonoBehaviour
{
    bool holdingPlus = false;
    bool holdingMinus = false;
    float fov;

    // Start is called before the first frame update
    void Start()
    {
        fov = Camera.main.fieldOfView;
        // CameraPos = Camera.main.transform.position;
        // defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
        // defaultHight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        // if (maintainWith) {
        //     Camera.main.orthographicSize=defaultWidth/Camera.main.aspect;
        //     Camera.main.transform.position = new Vector3(CameraPos.x, CameraPos.y, CameraPos.z);
        // }

        if(holdingPlus || holdingMinus) {
            if (Input.GetKeyUp(KeyCode.Plus) || Input.GetKeyUp(KeyCode.Equals)) {
                holdingPlus = false;
            } else if (holdingPlus) {
                fov -= fov > 40 ? 0.1f : 0;
                Camera.main.fieldOfView = fov;
            }
            if (Input.GetKeyUp(KeyCode.Minus) || Input.GetKeyUp(KeyCode.Minus)) {
                 holdingMinus = false;
            } else if (holdingMinus) {
                fov += fov < 75 ? 0.1f : 0;
                Camera.main.fieldOfView = fov;
            }
        } else {
            holdingPlus = false;
            holdingMinus = false;
            if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals)) {
                holdingPlus = true;
            }
            if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.Underscore)) {
                holdingMinus = true;
            }
        }
    }
}
