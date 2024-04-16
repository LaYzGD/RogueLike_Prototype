using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/Animations/CharacterAnimations", fileName = "CharacterAnimationsData")]
public class CharacterAnimationsData : ScriptableObject
{
    [field: SerializeField] public string IdleAnimationParameter { get; private set; }
    [field: SerializeField] public string MoveAnimationParameter { get; private set; }
    [field: SerializeField] public string InAirAnimationParameter { get; private set; }
    [field: SerializeField] public string JumpAnimationParameter { get; private set; }
    [field: SerializeField] public string AirAttack { get; private set; }
    [field: SerializeField] public string AttackForward { get; private set; }
    [field: SerializeField] public string AttackDown { get; private set; }
    [field: SerializeField] public string AttackNeutral { get; private set; }
}
