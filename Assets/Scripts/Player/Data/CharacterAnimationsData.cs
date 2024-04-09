using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/Animations/CharacterAnimations", fileName = "CharacterAnimationsData")]
public class CharacterAnimationsData : ScriptableObject
{
    [field: SerializeField] public string IdleAnimationParameter { get; private set; }
    [field: SerializeField] public string MoveAnimationParameter { get; private set; }
    [field: SerializeField] public string InAirAnimationParameter { get; private set; }
    [field: SerializeField] public string LandAnimationParameter { get; private set; }
    [field: SerializeField] public string JumpAnimationParameter { get; private set; }
}
