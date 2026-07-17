using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int highScore;

    public UnityEvent<int> OnScoreUpdated;
    public UnityEvent<int> OnHighScoreUpdated;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log("Score: " + score);
        OnScoreUpdated?.Invoke(score);

        if (score > highScore)
        {
            highScore = score;
            OnHighScoreUpdated?.Invoke(highScore);
            SaveHighScore();
        }
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}
