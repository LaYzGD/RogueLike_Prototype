using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player/Upgrades", fileName = "Upgrade")]
public class UpgradeData : ScriptableObject
{
    [field: SerializeField] public Sprite CardSprite { get; private set; }
    [field: SerializeField] public Sprite ObjectSprite { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public int Boost { get; private set; }
    [field: SerializeField] public UpgradeProperty UpgradeProperty { get; private set; }
}

public enum UpgradeProperty 
{
    Damage,
    Health,
    Speed,
    RestoreHealth
}
