using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/AttackStateData/AttackDown", fileName = "AttackDownData")]
public class AttackDownData : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float StunTime { get; private set; }
}
