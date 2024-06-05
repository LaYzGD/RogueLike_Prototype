using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private DamageCollider _damageCollider;
    
    private int _damage;

    public void Init(int damage)
    {
        _damage = damage;
        _damageCollider.Initialize(_damage);
    }
}
