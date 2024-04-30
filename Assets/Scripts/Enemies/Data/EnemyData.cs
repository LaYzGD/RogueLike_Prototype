using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/Main", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public float DetectionRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float ChaseSpeed { get; private set; }
    [field: SerializeField] public LayerMask GroundLayer { get; private set; }
    [field: SerializeField] public LayerMask TargetLayer { get; private set; }

    [field: SerializeField] public string IdleAnimation { get; private set; }
    [field: SerializeField] public string MoveAnimation { get; private set; }
    [field: SerializeField] public string ChaseAnimation { get; private set; }
    [field: SerializeField] public string AttackAnimation { get; private set; }
    [field: SerializeField] public EnemyBehaviourData EnemyBehaviourData { get; private set; }
}
