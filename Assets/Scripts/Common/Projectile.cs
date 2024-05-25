using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    [SerializeField] private string _despawnAnimation; 
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Rigidbody2D _body;

    private bool _canMove;
    private int _damage;
    private float _movementSpeed;
    private Vector2 _movementDirection;
    private Action<Projectile> _onDespawn;
    private LayerMask _nonInteractable;

    public void Initialize(Action<Projectile> despawnAction, Vector2 direction, ProjectileData data)
    {
        _onDespawn = despawnAction;
        _movementDirection = direction;
        _damage = data.Damage;
        _movementSpeed = data.MovementSpeed;
        _nonInteractable = data.NonInteractable;
        _body.gravityScale = data.GravityScale;
        _canMove = data.CanMove;
        if (!_canMove)
        {
            _body.velocity = new Vector2(_movementDirection.x * _movementSpeed, _movementDirection.y * _movementSpeed);
        }
        _animator.OnAnimationCompleted += Despawn;
    }

    private void FixedUpdate()
    {
        if (!_canMove) 
        {
            return;
        }

        _body.velocity = new Vector2(_movementDirection.x * _movementSpeed, _movementDirection.y * _movementSpeed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(_nonInteractable.value, 2))
        {
            return;
        }

        if (collision.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(_damage);
        }

        _animator.ChangeAnimationState(_despawnAnimation);
    }

    public void PlayParticles()
    {
        _particleSystem.Play();
    }

    public void StopMovement()
    {
        _body.velocity = Vector2.zero;
    }

    public void SetGravity(float gravity)
    {
        _body.gravityScale = gravity;
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
