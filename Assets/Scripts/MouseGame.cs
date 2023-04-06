using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGame : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    Rigidbody rb;
    Vector3 newPosition;
    public float speed;
    bool canMove = false;
    private Vector3 lastDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        newPosition = transform.position;
        lastDirection = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.collider.CompareTag("Floor"))
            {
                newPosition = hit.point;
                canMove = true;
                lastDirection = (newPosition - transform.position).normalized;
            }
        }
    }

    private void FixedUpdate()
    {
        if (newPosition != null)
        {
            if (canMove == true)
            {
                Quaternion lookRotation = Quaternion.LookRotation((newPosition - transform.position), Vector3.up);
                transform.rotation = lookRotation;
                rb.AddForce((newPosition - transform.position).normalized * speed * Time.deltaTime);

                if ((transform.position - newPosition).magnitude < 0.1f)
                {
                    canMove = false;
                }
                else if(Vector3.Distance(transform.position, newPosition) < 6)
                {
                    Quaternion lookRotationStop = Quaternion.LookRotation(lastDirection, Vector3.up);
                    transform.rotation = lookRotationStop;
                } 
            }
        }
    }
}