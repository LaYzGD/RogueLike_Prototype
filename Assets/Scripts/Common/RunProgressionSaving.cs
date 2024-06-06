using UnityEngine;

public class RunProgressionSaving : MonoBehaviour
{
    private const string _movementSpeed = "PLAYER_MOVEMENT_SPEED";
    private const string _damage = "PLAYER_DAMAGE";
    private const string _maxHealth = "MAX_HEALTH";
    private const string _currentHealth = "CURRENT_HEALTH";
    public PlayerDataValues Load(PlayerData baseData)
    {
        var maxHealth = PlayerPrefs.GetInt(_maxHealth, baseData.MaxHealth);
        var currentHealth = PlayerPrefs.GetInt(_currentHealth, baseData.MaxHealth);
        var damage = PlayerPrefs.GetInt(_damage, baseData.Damage);
        var movementSpeed = PlayerPrefs.GetFloat(_movementSpeed, baseData.MoveStateData.MovementSpeed);
        PlayerDataValues data = new PlayerDataValues(maxHealth, currentHealth, damage, movementSpeed);
        return data;
    }

    public void Save(PlayerDataValues data)
    {
        PlayerPrefs.SetFloat(_movementSpeed, data.MovementSpeed);
        PlayerPrefs.SetInt(_damage, data.Damage);
        PlayerPrefs.SetInt(_maxHealth, data.MaxHealth);
        PlayerPrefs.SetInt(_currentHealth, data.CurrentHealth);
    }
}

public struct PlayerDataValues
{
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public int Damage { get; private set; }
    public float MovementSpeed { get; private set; }

    public PlayerDataValues(int maxHealth, int currentHealth, int damage, float movementSpeed)
    {
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
        Damage = damage;
        MovementSpeed = movementSpeed;
    }
}
