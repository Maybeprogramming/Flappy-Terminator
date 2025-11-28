using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioProvider : MonoBehaviour
{
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _rocketSound;
    [SerializeField] private AudioClip _laserSound;
    [SerializeField] private AudioClip _explouseSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClips audioClip)
    {
        _audioSource.PlayOneShot(TakeAudioClip(audioClip));
    }

    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }

    private AudioClip TakeAudioClip(AudioClips audioClip)
    {
        AudioClip clip = audioClip switch
        {
            AudioClips.GameOver => _gameOverSound,
            AudioClips.Rocket => _rocketSound,
            AudioClips.Laser => _laserSound,
            AudioClips.Explouse => _explouseSound,
            _ => throw new ArgumentException(nameof(audioClip)),
        };

        return clip;
    }
}
