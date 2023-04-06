using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    BoxCollider playerCollider;
    bool invencibilityFrame = false;
    private void Start()
    {
        playerCollider = GetComponent<BoxCollider>();
        gameObject.GetComponent<Material>().color = Color.red;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!invencibilityFrame)
            {
                GameManager.Instance.Hit();
                Invoke("InvencibilityOn",0);
            }
            Destroy(other.gameObject);
        }
        if (other.CompareTag("PowerUp"))
        {
            GameManager.Instance.PowerUp();
        }
    }

    void InvencibilityOn()
    {
        invencibilityFrame = true;
        gameObject.GetComponent<Material>().color = Color.magenta;
        Invoke("invencibilityOff", 1);
    }
    void invencibilityOff()
    {
        invencibilityFrame= false;
        gameObject.GetComponent<Material>().color = Color.red;
    }
}
