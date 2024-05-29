using UnityEngine;

public class AnimationEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private float _minimumPitch = 0.7f;
    [SerializeField] private float _maximumPitch = 0.7f;
    [SerializeField] private AudioClip[] _randomSounds;
    [SerializeField] private ParticleSystem[] _animationParticles;
    [SerializeField] private Transform _particleSpawnPosition;

    public void PlayParticles(int index)
    {
        _animationParticles[index].transform.position = _particleSpawnPosition.position;
        _animationParticles[index].Play();
    }

    public void StopParticles(int index)
    {
        _animationParticles[index].Stop();
    }

    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    public void PlayRandomSound()
    {
        _audioSource.pitch = Random.Range(_minimumPitch, _maximumPitch);
        _audioSource.PlayOneShot(_randomSounds[Random.Range(0, _randomSounds.Length)]);
    }
    public void PlayDrums()
    {
        _musicSource.Play();
    }
}
