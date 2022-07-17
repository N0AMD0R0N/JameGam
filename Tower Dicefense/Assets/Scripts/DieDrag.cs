using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DieDrag : MonoBehaviour
{

    public GameObject selectedDie;
    public void Start() {
        selectedDie = null;
    }

    public void Update() {
        if ( Input.GetMouseButtonDown(0) ) { 
            if(selectedDie == null) {
                RaycastHit hit = CastRay();
                if ( hit.transform.tag == "ResourceDie") {
                    if(hit.transform.gameObject.GetComponent<ResourceDie>().stopped) {
                        selectedDie = hit.collider.gameObject;
                        Cursor.visible = false;
                    }
                }
            } else {
                selectedDie = null;
                Cursor.visible = true;
            }
        }

        if(selectedDie != null) {
            Vector3 position = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(selectedDie.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedDie.transform.position = new Vector3(
                worldPosition.x,
                5f,
                worldPosition.z);
        }
    }

    private RaycastHit CastRay() {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast (worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);
        return hit;
    }
}