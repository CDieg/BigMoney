using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.UpdateGameState(GameState.MainMenu);        

        score = PlayerPrefs.GetInt("PlayerScore");
        scoreText.SetText("SCORE: {0:000000000}", score);
    }

    public void ButtonMainMenu()
    {        
        SceneManager.LoadScene("MainMenu");
    }
}
