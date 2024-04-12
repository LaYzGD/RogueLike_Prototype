using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/AttackStateData/AttackForward", fileName = "AttackForwardData")]
public class AttackForwardData : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float ForwardMovement { get; private set; }
}
