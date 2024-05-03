using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/Stage", fileName = "Stage")]
public class Stage : ScriptableObject
{
    [field: SerializeField] public EnemyAttacks[] Stages { get; set; }
}
