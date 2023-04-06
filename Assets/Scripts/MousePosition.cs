using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    //pega camera e scripts.
    [SerializeField] Camera mainCamera;
    [SerializeField] MoveAndChange moveAndChange;
    public Vector3 newPosition;
    private void Start()
    {
        newPosition = transform.position;
    }
    private void Update()
    {
        //caso aperte bot�o do mouse entre.
        if (Input.GetMouseButton(0))
        {
            //Raycast em dire��o ao ch�o e salve a posi��o do hit no newposition.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.collider.CompareTag("Floor"))
            {
                newPosition = hit.point;
                Debug.Log(hit.collider.name);
                Debug.Log(newPosition);
                //tp posi��o atual para a nova.
                transform.position = newPosition;
            }
        }
    }
}
