using UnityEngine;

public class AnimationEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private float _minimumPitch = 0.7f;
    [SerializeField] private AudioClip[] _randomSounds;
    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    public void PlayRandomSound()
    {
        var startingPitch = _audioSource.pitch;
        _audioSource.pitch = Random.Range(_minimumPitch, startingPitch);
        _audioSource.PlayOneShot(_randomSounds[Random.Range(0, _randomSounds.Length)]);
        _audioSource.pitch = startingPitch;
    }
    public void PlayDrums()
    {
        _musicSource.Play();
    }
}
