using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/StateData/JumpState", fileName = "JumpStateData")]
public class JumpStateData : ScriptableObject
{
    [field: SerializeField] public float JumpForce { get; private set; }
}
