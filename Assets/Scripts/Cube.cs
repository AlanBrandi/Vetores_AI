using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //Pega script moveandgange.
    [SerializeField] MoveAndChange moveAndChange;
    bool passed = false;
    bool finished = false;
    float distance;
    //procura o player pega o componente dele.

    private void Update()
    {
        distance = Vector3.Distance(transform.position, moveAndChange.paths[moveAndChange.index].transform.position);
        if (distance < 1f)
        {
            if (finished == false)
            {
                moveAndChange.index++;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //se tiver colisão com player pega o index e muda ele, caso ja tenha passado pelo ultimo, parar quando chegar no 4.
        if (other.CompareTag("Player"))
        {
            if (moveAndChange.index > 3 && !passed)
            {
                passed = true;
            }
            else if (moveAndChange.index == 3 && passed)
            {
                finished = true;
            }
            if (passed)
            {
                moveAndChange.index = 3;
            }
            other.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
