using UnityEngine;

[CreateAssetMenu(menuName = "PlayerData/Items/Hook", fileName = "HookData")]
public class HookData : ScriptableObject
{
    [field: SerializeField] public float TravelDistance { get; private set; }
    [field: SerializeField] public float Distance { get; private set; }
    [field: SerializeField] public float LaunchSpeed { get; private set; }
    [field: SerializeField] public float ReturnSpeed { get; private set; }
    [field: SerializeField] public LayerMask ConnectableLayer { get; private set; }
}
