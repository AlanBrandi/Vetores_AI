using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToFixPosition : MonoBehaviour
{
    //
    [SerializeField] GameObject goPosition;
    public float speed;
    private void Start()
    {
        goPosition = GameObject.FindGameObjectWithTag("Player");
        speed = 3;
    }
    private void Update()
    {
        if(goPosition != null)
        {
            goPosition = GameObject.FindGameObjectWithTag("Player");
            Vector3 direction = goPosition.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
}
