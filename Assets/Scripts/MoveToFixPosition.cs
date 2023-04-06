using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToFixPosition : MonoBehaviour
{
    //Vari�veis.
    [SerializeField] GameObject goPosition;
    public float speed;
    //Pega posi��o atual do player e coloca no goPosition e adiciona velocidade do speed.
    private void Start()
    {
        goPosition = GameObject.FindGameObjectWithTag("Player");
        speed = 3;
    }
    private void Update()
    {
        //caso n�o tenha posi��o, pegue do player e va em dire��o a ele.
        if(goPosition != null)
        {
            goPosition = GameObject.FindGameObjectWithTag("Player");
            Vector3 direction = goPosition.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
}
