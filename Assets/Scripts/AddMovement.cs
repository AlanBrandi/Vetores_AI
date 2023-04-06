using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class AddMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 direction;
    Rigidbody rb;
    GameObject enemy1; 
    GameObject enemy2; 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

       // direction = enemy1.transform.position;



        //rb.AddForce(direction * speed);
    }
}
