using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/StateData/JumpState", fileName = "JumpStateData")]
public class JumpStateData : ScriptableObject
{
    [field: SerializeField] public float GravityScale { get; private set; }
    [field: SerializeField] public float JumpVerticalForce { get; private set; }
}
