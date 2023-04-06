using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variáveis.
    [SerializeField] GameObject player;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject deathPanel;
    [SerializeField] int lives = 3;
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text scoreDeathTxt;
    [SerializeField] TMP_Text livesTxt;
    //Singleton.
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
        //Adiciona alguns valores para as variáveis.
        score = 0;
        lives = 3;
        scoreTxt.text = score.ToString();
        livesTxt.text = lives.ToString();
        hud.SetActive(true);
        deathPanel.SetActive(false);
        Debug.Log(lives);
    }
    //Método Hit, pega a vida do jogador diminuir em 1, atualiza no HUD, e caso a vida esteja menor que ou igual a 0 acionar método Die.
    public void Hit()
    {
        lives--;
        livesTxt.text = lives.ToString();
        if (lives <= 0)
        {
            Die();
        }
        Debug.Log("Vida do player: " +lives);
    }
    //Desativa a HUD, ativa a tela de morte e destroi jogador.
    void Die()
    {
        hud.SetActive(false);
        Destroy(player.gameObject);
        deathPanel.SetActive(true);
    }
    //Pega vida do jogador some em 1, atualiza na HUD.
    public void PowerUp()
    {
        lives++;
        livesTxt.text = lives.ToString();
        Debug.Log("Vida do player: " + lives);
    }
    //Pega o score e soma em 1, e atualiza nas telas de Morte e HUD.
    public void AddScore()
    {
        score++;
        scoreTxt.text = score.ToString();
        scoreDeathTxt.text = score.ToString();
    }
    //Da load na mesma scena.
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
}
