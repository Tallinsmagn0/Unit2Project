using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    bool isSubscribedToEvents = true;

    private void OnEnable()
    {
        if (isSubscribedToEvents == false)
            SubscribeToEvents();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        UnsubscribeToEvents();
        isSubscribedToEvents = false;
    }

    void SubscribeToEvents()
    {
        GameManager.GetInstance().GetPlayer().health.OnHealthUpdate += UpdateHealth;

        GameManager.GetInstance().GetScoreManager().OnScoreUpdated.AddListener(UpdateScore);
        GameManager.GetInstance().GetScoreManager().OnHighScoreUpdated.AddListener(UpdateHighScore);

        isSubscribedToEvents = true;
    }

    void UnsubscribeToEvents()
    {
        GameManager.GetInstance().GetPlayer().health.OnHealthUpdate -= UpdateHealth;

        GameManager.GetInstance().GetScoreManager().OnScoreUpdated.RemoveListener(UpdateScore);
        GameManager.GetInstance().GetScoreManager().OnHighScoreUpdated.RemoveListener(UpdateHighScore);

        isSubscribedToEvents = false;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
