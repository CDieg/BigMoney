using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.SetText("SCORE: {0:000000000}", score);
    }
    public void AddPoints (int points)
    {
        score += points;
        UpdateScore();
        SaveScore();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("PlayerScore", score);
    }
}
