using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;

    bool gameHasEnded = false;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError($"Found duplicate GameManager instance on {gameObject.name}");
            Destroy(gameObject);
            return;
        }

        instance = this;

        SoundManager.Initialize();
    }

    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                GameManager.instance.UnlockCursor();
                break;
            case GameState.Play:
                Time.timeScale = 1f;
                break;
            case GameState.Pause:
                Time.timeScale = 0f;
                GameManager.instance.UnlockCursor();
                break;
            case GameState.NextLevel:
                break;
            case GameState.GameOver:
                GameManager.instance.UnlockCursor();
                break;
            case GameState.Win:
                break;
        }

        // Check if not null
        OnGameStateChanged?.Invoke(newState);
    }
    public void GameOver()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Win()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            SceneManager.LoadScene("Win");
        }
    }

    public void NextLevel()
    {
        if (!gameHasEnded)
        {            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.SetActiveScene(SceneManager.GetActiveScene());
            UpdateGameState(GameState.Play);
        }
    }
    private void Restart()
    {
        SaveData.score = 0;
        SceneManager.LoadScene(0);
    }
    public void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

public enum GameState
{
    MainMenu,
    Play,
    Pause,
    NextLevel,
    GameOver,
    Win
}