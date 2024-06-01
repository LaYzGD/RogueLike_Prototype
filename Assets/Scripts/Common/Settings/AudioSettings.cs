using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private float _volumeNormalizer = 20f;
    [SerializeField] private string _master;
    [SerializeField] private string _enemies;
    [SerializeField] private string _player;
    [SerializeField] private string _music;
    public void SetMasterVolume(float level) 
    {
        _mixer.SetFloat(_master, Mathf.Log10(level) * _volumeNormalizer);
    }

    public void SetEnemiesVolume(float level) 
    {
        _mixer.SetFloat(_enemies, Mathf.Log10(level) * _volumeNormalizer);
    }
    
    public void SetPlayerVolume(float level) 
    {
        _mixer.SetFloat(_player, Mathf.Log10(level) * _volumeNormalizer);
    }

    public void SetMusicVolume(float level) 
    {
        _mixer.SetFloat(_music, Mathf.Log10(level) * _volumeNormalizer);
    }
}
