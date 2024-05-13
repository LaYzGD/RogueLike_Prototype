using UnityEngine;

public class EnemyHitEffects : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Transform _body;
    [SerializeField] private ParticleSystem[] _hitParticles;
    [SerializeField] private ParticleSystem _destroyParticles;

    private void OnEnable()
    {
        _health.OnDamaged += HitEffect;
        _health.OnDie += DeathEffect;
    }

    private void HitEffect(int health)
    {
        foreach (var hit in _hitParticles) 
        {
            hit.gameObject.transform.position = _body.position;
            hit.Play();
        }
    }

    private void DeathEffect()
    {
        _destroyParticles.gameObject.transform.position = _body.position;
        _destroyParticles.Play();
    }

    private void OnDisable()
    {
        _health.OnDamaged -= HitEffect;
        _health.OnDie -= DeathEffect;
    }
}
