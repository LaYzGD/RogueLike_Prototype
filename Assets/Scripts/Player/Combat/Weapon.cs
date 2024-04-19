using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private DamageCollider _damageCollider;
    [SerializeField] private int _damage;

    private void Start()
    {
        _damageCollider.Initialize(_damage);
    }
}
