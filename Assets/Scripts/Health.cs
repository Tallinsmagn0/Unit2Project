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
    }

    public Health()
    {
        
    }

    public void AddHealth(float value)
    {
        currentHealth += value;
    }

    public void DeductHealth(float value)
    {
        currentHealth -= value;
    }

    public float GetHealth()
    {
        return currentHealth;
    }
}
