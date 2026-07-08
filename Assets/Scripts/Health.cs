using UnityEngine;

public class Health
{
    private float maxHealth;
    private float healthRegenRate;
    private float currentHealth;

    public Health(float _maxHealth, float _healthRegenRate, float _currentHealth)
    {
        maxHealth = _maxHealth;
        healthRegenRate = _healthRegenRate;
        currentHealth = _currentHealth;
    }

    public Health(float _maxHealth)
    {
        maxHealth = _maxHealth;
        currentHealth = _maxHealth;
    }

    public Health()
    {
        
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(float health)
    {
        currentHealth = health;
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Min(currentHealth + value, maxHealth);
    }

    public void DeductHealth(float value)
    {
        currentHealth = Mathf.Max(currentHealth - value, 0);
    }

    public void RegenHealth()
    {
        AddHealth(healthRegenRate * Time.deltaTime);
    }
}
