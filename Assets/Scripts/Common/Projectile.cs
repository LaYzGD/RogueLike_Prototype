using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private Rigidbody2D _body;

    private bool _canMove;
    private int _damage;
    private float _movementSpeed;
    private Vector2 _movementDirection;
    private Action<Projectile> _onDespawn;
    private LayerMask _damageLayer;

    public void Initialize(Action<Projectile> despawnAction, Vector2 direction, ProjectileData data)
    {
        _onDespawn = despawnAction;
        _movementDirection = direction;
        _damage = data.Damage;
        _movementSpeed = data.MovementSpeed;
        _damageLayer = data.DamageLayer;
        _body.gravityScale = data.GravityScale;
        _canMove = data.CanMove;
        _animator.OnAnimationCompleted += Despawn;
    }

    private void FixedUpdate()
    {
        if (!_canMove) return;

        _body.velocity = _movementDirection * _movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != Mathf.Log(_damageLayer.value, 2))
        {
            return;
        }

        if (collision.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(_damage);
        }

        Despawn();
    }

    private void Despawn()
    {
        _onDespawn(this);
    }

    private void OnDisable()
    {
        _animator.OnAnimationCompleted -= Despawn;
    }
}
