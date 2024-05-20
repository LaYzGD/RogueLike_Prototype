using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    private int _maxHealth;

    private int _currentHealth;
    private bool _isImune;

    public event Action<int> OnDamaged;
    public event Action OnDie;

    public void Init(int maxHealth, bool isImune)
    {
        _isImune = isImune;
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
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
        OnDamaged?.Invoke(_currentHealth);
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
