using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    //
    [SerializeField] Camera mainCamera;
    [SerializeField] MoveAndChange moveAndChange;
    public Vector3 newPosition;
    private void Start()
    {
        newPosition = transform.position;
    }
    private void Update()
    {
        //
        if (Input.GetMouseButton(0))
        {
            //
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.collider.CompareTag("Floor"))
            {
                newPosition = hit.point;
                Debug.Log(hit.collider.name);
                Debug.Log(newPosition);
                //
                transform.position = newPosition;
            }
        }
    }
}
