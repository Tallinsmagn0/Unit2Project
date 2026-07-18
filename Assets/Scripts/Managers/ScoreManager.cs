using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int highScore;

    private string highScoreKey = "HighScore";

    public UnityEvent<int> OnScoreUpdated;
    public UnityEvent<int> OnHighScoreUpdated;

    private bool isInitialScoreLoaded = false;

    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey);
    }

    void Update()
    {
        if (!isInitialScoreLoaded)
        {
            OnScoreUpdated?.Invoke(score);
            OnHighScoreUpdated?.Invoke(highScore);
            isInitialScoreLoaded = true;
        }
    }

    public int GetScore()
    {
        OnScoreUpdated?.Invoke(score);
        return score;
    }

    public int GetHighScore()
    {
        OnHighScoreUpdated?.Invoke(highScore);
        return highScore;
    }

    public void IncrementScore()
    {
        IncrementScore(1);
    }

    public void IncrementScore(int points)
    {
        score += points;
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
        PlayerPrefs.SetInt(highScoreKey, highScore);
    }
}
