using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;

    bool gameHasEnded = false;
    [SerializeField]
    private float restartDelay;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError($"Found duplicate ScoreManager instance on {gameObject.name}");
            Destroy(gameObject);
            return;
        }

        instance = this;
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
                break;
            case GameState.Pause:
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

    private void Restart()
    {
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
    GameOver,
    Win
}