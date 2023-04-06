using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //Pega script moveandgange.
     [SerializeField] MoveAndChange moveAndChange;
    bool passed = false;
    //procura o player pega o componente dele.
    private void Start()
    {
        moveAndChange = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveAndChange>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //se tiver colisão com player pega o index e muda ele, caso ja tenha passado pelo ultimo, parar quando chegar no 4.
        if (other.CompareTag("Player"))
        {
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
