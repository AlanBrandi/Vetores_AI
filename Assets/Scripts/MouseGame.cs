using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGame : MonoBehaviour
{
    //Variáveis.
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layer;
    Rigidbody rb;
    Vector3 newPosition;
    public float speed;
    bool canMove = false;
    private Vector3 lastDirection;
    //Pega alguns componestes e da set na ultima direção.
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        newPosition = transform.position;
        lastDirection = Vector3.zero;
    }
    //Caso aperte o botão do mouse, ativa raycast que colide com chão e pega a posição do hit, adiciona a variavel newPosition.
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, layer) && hit.collider.CompareTag("Floor"))
            {
                newPosition = hit.point;
                canMove = true;
                lastDirection = (newPosition - transform.position).normalized;
            }
        }
    }
    //Caso possa se mover, vai em direção ao newPosition olhando para a direçao, se tiver chegando 
    //olhe para ultima posição que estava e caso sua posição seja igual, pare de andar.
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