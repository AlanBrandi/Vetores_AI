using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndChange : MonoBehaviour
{
    //Index, velocidade e lista para as posições.
    public int index = 0;
    public float speed = 10;
    public List<GameObject> paths = new List<GameObject>();
    Vector3 direction;
    //anda na direção do gameobject com certa velocidade.
    private void Update()
    {
        direction = paths[index].transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
