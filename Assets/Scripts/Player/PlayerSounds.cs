using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private float _minPitch = 0.7f;
    [SerializeField] private float _maxPitch = 1f;
    [Space]
    [SerializeField] private AudioSource _hitSoundsSource;
    [SerializeField] private AudioSource _abilitySoundsSource;

    public void PlayHitSound(AudioClip clip)
    {
        _hitSoundsSource.pitch = Random.Range(_minPitch, _maxPitch);
        _hitSoundsSource.PlayOneShot(clip);
    }

    public void PlayAbilitySound(AudioClip clip) 
    {
        _abilitySoundsSource.pitch = Random.Range(_minPitch, _maxPitch);
        _abilitySoundsSource.PlayOneShot(clip);
    }
}
