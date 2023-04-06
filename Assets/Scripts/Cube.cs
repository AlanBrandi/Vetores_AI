using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //
     [SerializeField] MoveAndChange moveAndChange;
    bool passed = false;
    //
    private void Start()
    {
        moveAndChange = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveAndChange>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //
        if (other.CompareTag("Player"))
        {
            //
            if(moveAndChange.index != 4 && passed == false)
            {
                moveAndChange.index = moveAndChange.index + 1;
                passed = true;
            }
            else
            {
                moveAndChange.index = 3;
            }
        }
    }
}
