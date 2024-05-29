using UnityEngine;

public class EnemyHitEffects : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Transform _body;
    [SerializeField] private ParticleSystem[] _hitParticles;
    [SerializeField] private ParticleSystem _destroyParticles;
    [Space]
    [SerializeField] private AudioClip[] _hitSounds;
    [SerializeField] private AudioClip[] _gruntSounds;
    [SerializeField] private AudioSource _hitSoundSource;
    [SerializeField] private AudioSource _gruntSoundSource;
    [Space]
    [SerializeField] private float _maxPitch = 1.5f;
    [SerializeField] private float _minPitch = 0.8f;

    private Vector2 _basicParticleRotation = Vector2.right;
    private void OnEnable()
    {
        _health.OnDamaged += HitEffect;
        _health.OnDie += DeathEffect;
    }

    private void HitEffect(int health, Vector2 direction)
    {
        foreach (var hit in _hitParticles) 
        {
            hit.gameObject.transform.position = _body.position;
            hit.gameObject.transform.rotation = Quaternion.FromToRotation(_basicParticleRotation, direction);
            hit.Play();
        }

        _hitSoundSource.pitch = UnityEngine.Random.Range(_minPitch, _maxPitch);
        _gruntSoundSource.pitch = UnityEngine.Random.Range(_minPitch, _maxPitch);

        _hitSoundSource.PlayOneShot(_hitSounds[UnityEngine.Random.Range(0, _hitSounds.Length)]);
        _gruntSoundSource.PlayOneShot(_gruntSounds[UnityEngine.Random.Range(0, _gruntSounds.Length)]);
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
