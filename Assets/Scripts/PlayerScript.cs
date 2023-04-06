using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Variáveis.
    BoxCollider playerCollider;
    bool invencibilityFrame = false;
    Material playerMaterial;
    //Pega o BoxCollider do player, o material e troca para vermelho.
    private void Start()
    {
        playerCollider = GetComponent<BoxCollider>();
        playerMaterial = gameObject.GetComponent<Renderer>().material;
        playerMaterial.color = Color.red;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            //Caso tenha colisão e for inimigo entre.
            case "Enemy":
                //se acaso vc não esteja com invencivilidade pegue o GameManager e de dano no player, e ligue a invencibilidade.
                if (!invencibilityFrame)
                {
                    GameManager.Instance.Hit();
                    Invoke("InvencibilityOn", 0);
                }
                Destroy(other.gameObject);
                break;
            //Caso tenha colisão e for PowerUp entre.
            case "PowerUp":
                //Adiciona um de vida ao jogador utilizando o GameManager.
                GameManager.Instance.PowerUp();
                Destroy(other.gameObject);
                break;
            //Caso tenha colisão e for point entre.
            case "Point":
                //Adiciona um de vida ao jogador utilizando o GameManager.
                GameManager.Instance.AddScore();
                Destroy(other.gameObject);
                break;
        }
    }
    //Ligar e desligar a invencivilidade + trocar a cor do material para rosa para feedback.
    void InvencibilityOn()
    {
        invencibilityFrame = true;
        playerMaterial.color = Color.magenta;
        Invoke("invencibilityOff", 1);
    }
    void invencibilityOff()
    {
        invencibilityFrame= false;
        playerMaterial.color = Color.red;
    }
}
