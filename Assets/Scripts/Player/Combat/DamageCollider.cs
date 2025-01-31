using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField] private LayerMask _damagableLayer;

    private int _damage;

    public void Initialize(int damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != Mathf.Log(_damagableLayer.value, 2))
        {
            return;
        }

        if (collision.TryGetComponent(out IDamagable damagable))
        {
            Vector2 direction = collision.transform.position - transform.position;
            damagable.TakeDamage(_damage, direction.normalized);
        }
        else 
        {
            print(collision.gameObject.name);
        }
    }
}
