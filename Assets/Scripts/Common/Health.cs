using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    private int _maxHealth;

    private int _currentHealth;
    private bool _isImune;

    public event Action<int, int> OnInitialized;
    public event Action<int, Vector2> OnDamaged;
    public event Action<int> OnHeal;
    public event Action OnDie;

    public int CurrentHealth => _currentHealth;

    public void Init(int maxHealth, int currentHealth, bool isImune)
    {
        _isImune = isImune;
        _maxHealth = maxHealth;
        _currentHealth = currentHealth;
        OnInitialized?.Invoke(_currentHealth, _maxHealth);
    }

    public void UpdateMaxHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
        OnInitialized?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(int damage, Vector2 direction)
    {
        if (damage <= 0)
        {
            return;
        }

        if (_isImune)
        {
            return;
        }

        _currentHealth -= damage;
        OnDamaged?.Invoke(_currentHealth, direction);
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDie?.Invoke();
            return;
        }
    }

    public void Heal(int amount)
    {
        if (_currentHealth <= 0)
        {
            return;
        }

        if (amount <= 0)
        {
            return;
        }

        _currentHealth += amount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        OnHeal?.Invoke(_currentHealth);
    }

    public void SetImune(bool value) 
    {
        _isImune = value;
    }

    public void Restart()
    {
        _currentHealth = _maxHealth;
    }
}
