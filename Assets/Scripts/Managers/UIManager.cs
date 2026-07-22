using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameStats;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    bool isSubscribedToEvents = false;

    private void OnEnable()
    {
        if (isSubscribedToEvents == false)
            SubscribeToEvents();
    }

    private void OnDisable()
    {
        UnsubscribeToEvents();
        isSubscribedToEvents = false;
    }

    private void OnGameStart()
    {
        menuCanvas.SetActive(false);
        gameOverScreen.SetActive(false);
        gameStats.SetActive(true);
    }

    private void OnGameEnd()
    {
        gameOverScreen?.SetActive(true);
        gameStats.SetActive(false);
    }

    void Update()
    {
        if (GameManager.GetInstance().GetPlayer() != null)
        {
            SubscribePlayerHealth();
        }
    }

    void SubscribeToEvents()
    {
        GameManager.GetInstance().GetScoreManager().OnScoreUpdated.AddListener(UpdateScore);
        GameManager.GetInstance().GetScoreManager().OnHighScoreUpdated.AddListener(UpdateHighScore);

        GameManager.GetInstance().OnGameStart.AddListener(OnGameStart);
        GameManager.GetInstance().OnGameEnd.AddListener(OnGameEnd);

        isSubscribedToEvents = true;
    }

    void UnsubscribeToEvents()
    {
        GameManager.GetInstance().GetPlayer().health.OnHealthUpdate -= UpdateHealth;

        GameManager.GetInstance().GetScoreManager().OnScoreUpdated.RemoveListener(UpdateScore);
        GameManager.GetInstance().GetScoreManager().OnHighScoreUpdated.RemoveListener(UpdateHighScore);

        GameManager.GetInstance().OnGameStart.RemoveListener(OnGameStart);
        GameManager.GetInstance().OnGameEnd.RemoveListener(OnGameEnd);

        isSubscribedToEvents = false;
    }

    public void SubscribePlayerHealth()
    {
        GameManager.GetInstance().GetPlayer().health.OnHealthUpdate += UpdateHealth;
    }

    void UpdateHealth(float health)
    {
        healthText.text = $"Health: {health.ToString("0.0")}";
    }

    void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    void UpdateHighScore(int highScore)
    {
        highScoreText.text = $"High Score: {highScore}";
    }
}
