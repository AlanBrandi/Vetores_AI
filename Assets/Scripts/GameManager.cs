using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //
    [SerializeField] GameObject player;
    [SerializeField] GameObject hud;
    [SerializeField] GameObject deathPanel;
    [SerializeField] int lives = 3;
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text scoreDeathTxt;
    [SerializeField] TMP_Text livesTxt;
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
        score = 0;
        lives = 3;
        scoreTxt.text = score.ToString();
        livesTxt.text = lives.ToString();
        hud.SetActive(true);
        deathPanel.SetActive(false);
        Debug.Log(lives);
    }
    //
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
    //
    void Die()
    {
        hud.SetActive(false);
        Destroy(player.gameObject);
        deathPanel.SetActive(true);
    }
    //
    public void PowerUp()
    {
        lives++;
        livesTxt.text = lives.ToString();
        Debug.Log("Vida do player: " + lives);
    }
    //
    public void AddScore()
    {
        score++;
        scoreTxt.text = score.ToString();
        scoreDeathTxt.text = score.ToString();
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
}
