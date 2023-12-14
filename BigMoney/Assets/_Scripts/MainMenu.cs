using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject options;
    [SerializeField]
    private GameObject controls;

    private void Start()
    {
        GameManager.instance.UpdateGameState(GameState.MainMenu);

        // Reset score
        PlayerPrefs.SetInt("PlayerScore", 0);
        mainMenu.SetActive(true);
        controls.SetActive(false);
        options.SetActive(false);
    }
    
    public void ButtonPlay ()
    {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }
    public void ButtonOptions () 
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
    public void ButtonBack()
    {
        options.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void ButtonQuit() 
    {
        Application.Quit();
    }
}
