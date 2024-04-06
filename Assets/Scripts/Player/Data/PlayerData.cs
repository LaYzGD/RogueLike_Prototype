using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/MainData", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [field: SerializeField] public GroundCheckData GroundCheckData { get; private set; }
    [field: SerializeField] public AirStateData AirStateData { get; private set; }
    [field: SerializeField] public MoveStateData MoveStateData { get; private set; }
    [field: SerializeField] public CharacterAnimationsData CharacterAnimationsData { get; private set; }
}
