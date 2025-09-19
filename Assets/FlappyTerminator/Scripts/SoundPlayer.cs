using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [Header("Звуки")]
    [SerializeField] private AudioClip _gameoverSound;
    [SerializeField] private AudioClip _runRocketSound;
    [SerializeField] private AudioClip _runLaserSound;
    [SerializeField] private AudioClip explouseSound;
    [SerializeField] private float _delayBeforePlay;

    private AudioSource _audioSource;
    private WaitForSeconds _wait;

    private void Awake() => 
        _audioSource = GetComponent<AudioSource>();

    public void PlayOneShot(Sounds clip) => 
        StartCoroutine(SoundPlaying(clip));

    private IEnumerator SoundPlaying(Sounds clip)
    {
        yield return _wait;
        _audioSource.PlayOneShot(GetClip(clip));
    }

    private AudioClip GetClip(Sounds clip)
    {
        AudioClip audioClip = clip switch
        {
            Sounds.GameOver => _gameoverSound,
            Sounds.FireRocket => _runRocketSound,
            Sounds.FireLaser => _runLaserSound,
            Sounds.Explouse => explouseSound,
            _ => throw new Exception($"{nameof(clip)} ошибка передачи значения параметра в функцию {nameof(GetClip)}")
        };

        return audioClip;
    }
}