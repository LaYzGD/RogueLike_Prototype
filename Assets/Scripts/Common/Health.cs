using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event Action OnDamaged;
    public event Action OnDie;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }

        _currentHealth -= damage;
        OnDamaged?.Invoke();
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDie?.Invoke();
            return;
        }
    }

    public void Restart()
    {
        _currentHealth = _maxHealth;
    }
}
