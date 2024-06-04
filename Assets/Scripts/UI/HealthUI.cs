using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    
    private Health _health;

    public void Init(Health health)
    {
        _health = health;
        _health.OnInitialized += SetUpSlider;
        _health.OnDamaged += UpdateSlider;
    }

    private void SetUpSlider(int currentHealth)
    {
        _healthSlider.maxValue = currentHealth;
        Debug.Log(_healthSlider.maxValue);
        Debug.Log(currentHealth);
        _healthSlider.value = currentHealth;
    }

    private void UpdateSlider(int currentHealth, Vector2 none)
    {
        _healthSlider.value = currentHealth;
    }
}
