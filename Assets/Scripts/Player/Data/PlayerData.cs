using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/MainData", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public float ImunityFramesTime { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public GroundCheckData GroundCheckData { get; private set; }
    [field: SerializeField] public AirStateData AirStateData { get; private set; }
    [field: SerializeField] public MoveStateData MoveStateData { get; private set; }
    [field: SerializeField] public JumpStateData JumpStateData { get; private set; }
    [field: SerializeField] public DashStateData DashStateData { get; private set; }
    [field: SerializeField] public CharacterAnimationsData CharacterAnimationsData { get; private set; }

    public float MovementSpeed { get; private set; }

    public void SetUp(PlayerDataValues values)
    {
        MaxHealth = values.MaxHealth;
        Damage = values.Damage;
        MovementSpeed = values.MovementSpeed;
    }

    public void UpdateData(UpgradeProperty property, int boostAmount)
    {
        switch (property) 
        {
            case UpgradeProperty.Health:
                if (MaxHealth + boostAmount <= 0)
                {
                    MaxHealth = 1;
                    break;
                }
                MaxHealth += boostAmount;
                break;
            case UpgradeProperty.Speed:
                if(MovementSpeed + boostAmount <= 0) 
                {
                    MovementSpeed = 1;
                    break;
                }
                MovementSpeed += boostAmount;
                break;
            case UpgradeProperty.Damage:
                if (Damage + boostAmount <= 0)
                {
                    Damage = 1;
                    break;
                }
                Damage += boostAmount;
                break;
        }
    }
}
