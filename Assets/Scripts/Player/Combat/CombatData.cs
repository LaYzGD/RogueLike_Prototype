using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/CombatData", fileName = "CombatData")]
public class CombatData : ScriptableObject
{
    [field: SerializeField] public string IdleAttackParamName { get; private set; }
    [field: SerializeField] public string HorizontalAttackParamName { get; private set; }
    [field: SerializeField] public string UpAttackParamName { get; private set; }
    [field: SerializeField] public string DownAttackParamName { get; private set; }
}
