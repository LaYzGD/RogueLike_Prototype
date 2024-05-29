using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.OnInitialized += SetUpSlider;
        _health.OnDamaged += UpdateSlider;
    }

    private void SetUpSlider(int currentHealth)
    {
        _healthSlider.maxValue = currentHealth;
        _healthSlider.value = currentHealth;
    }

    private void UpdateSlider(int currentHealth, Vector2 none)
    {
        _healthSlider.value = currentHealth;
    }
}
