using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    private int _maxHealth;

    private int _currentHealth;
    private bool _isImune;

    public event Action<int> OnInitialized;
    public event Action<int, Vector2> OnDamaged;
    public event Action OnDie;

    public void Init(int maxHealth, bool isImune)
    {
        _isImune = isImune;
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
        OnInitialized?.Invoke(_currentHealth);
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

    public void SetImune(bool value) 
    {
        _isImune = value;
    }

    public void Restart()
    {
        _currentHealth = _maxHealth;
    }
}
