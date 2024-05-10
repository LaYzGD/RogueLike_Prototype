using UnityEngine;

[CreateAssetMenu(menuName = "Data/ProjectileData", fileName = "ProjectileData")]
public class ProjectileData : ScriptableObject
{
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float GravityScale { get; private set; }
    [field: SerializeField] public LayerMask DamageLayer { get; private set; }
    [field: SerializeField] public bool CanMove { get; private set; }
}
