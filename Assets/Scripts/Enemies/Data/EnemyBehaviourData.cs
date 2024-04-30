using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemies/EnemyBehaviourData", fileName = "EnemyBehaviourData")]
public class EnemyBehaviourData : ScriptableObject
{
    [field: SerializeField] public EnemyBehaviourType Idle { get; private set; }
    [field: SerializeField] public EnemyBehaviourType TargetSpoted { get; private set; }
}
