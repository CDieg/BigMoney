using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;


    private void Start()
    {
        score = 0;
        scoreText.SetText("SCORE: {0:000000000}", score);
    }
    void AddScore (int points)
    {
        score += points;
        scoreText.SetText("SCORE: {0:000000000}", score);
    }
}
