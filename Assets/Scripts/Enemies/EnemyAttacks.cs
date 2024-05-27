using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/EnemyAttacks", fileName = "EnemyAttacks")]
public class EnemyAttacks : ScriptableObject
{
    [field: SerializeField] public List<EnemyStateDataBase> DefaultAttacks { get; private set; }
    [field: SerializeField] public List<EnemyStateDataBase> CloseAttacks { get; private set; }
    [field: SerializeField] public List<EnemyStateDataBase> DistantAttacks { get; private set; }
    [field: SerializeField] public bool IsDefaultAttacksInOrder { get; private set; }
    [field: SerializeField] public AnimatorOverrideController Controller { get; private set; }
}
