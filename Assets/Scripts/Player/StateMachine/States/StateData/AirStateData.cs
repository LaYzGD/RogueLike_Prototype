using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/StateData/AirState", fileName = "AirStateData")]
public class AirStateData : ScriptableObject
{
    [field: SerializeField] public float FallVelocity { get; private set; }
    [field: SerializeField] public float HorizontalSpeed { get; private set; }
}
