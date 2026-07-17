using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TMP_Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.GetInstance().GetPlayer().health.OnHealthUpdate += UpdateHealth;
    }

    void UpdateHealth(float health)
    {
        healthText.text = $"Health: {health}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
