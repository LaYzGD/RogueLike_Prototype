using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _healthText;
    
    private Health _health;

    public void Init(Health health)
    {
        _health = health;
        _health.OnInitialized += SetUpSlider;
        _health.OnDamaged += UpdateSlider;
        _health.OnHeal += UpdateSlider;
    }

    private void SetUpSlider(int currentHealth, int maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthText.text = $"{currentHealth} / {maxHealth}";
        _healthSlider.value = currentHealth;
    }

    private void UpdateSlider(int currentHealth, Vector2 none)
    {
        _healthSlider.value = currentHealth;
        _healthText.text = $"{_healthSlider.value} / {_healthSlider.maxValue}";
    }

    private void UpdateSlider(int currentHealth)
    {
        _healthSlider.value = currentHealth;
        _healthText.text = $"{_healthSlider.value} / {_healthSlider.maxValue}";
    }
}
