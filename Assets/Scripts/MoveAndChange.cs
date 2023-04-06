using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndChange : MonoBehaviour
{
    //
    public int index = 0;
    public float speed = 10;
    [SerializeField] List<GameObject> paths = new List<GameObject>();
    Vector3 direction;
    //
    private void Update()
    {
        direction = paths[index].transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
