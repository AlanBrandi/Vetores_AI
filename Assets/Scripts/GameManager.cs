using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] int lives = 3;
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion[

    private void Start()
    {
        lives = 3;
        Debug.Log(lives);
    }
    public void Hit()
    {
        lives--;
        if(lives <= 0)
        {
            Die();
        }
        Debug.Log("Vida do player: " +lives);
    }
    void Die()
    {
        //HUDRetry
        Destroy(Player.gameObject);
    }
    public void PowerUp()
    {
       lives++;
       Debug.Log("Vida do player: " + lives);
    }
}
