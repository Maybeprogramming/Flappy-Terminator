using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [Header("Звуки")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _gameoverFX;
    [SerializeField] private AudioClip _rocketFX;
    [SerializeField] private AudioClip _laserFX;
    [SerializeField] private AudioClip _explouseFX;
    [SerializeField] private float _delayBeforePlay;

    [Header("Спавнеры")]
    [SerializeField] private RocketSpawner _rocketSpawner;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _rocketSpawner.RocketSpawned += OnRocketSpawned;
    }
    private void OnDisable()
    {
        _rocketSpawner.RocketSpawned -= OnRocketSpawned;
    }

    private void OnRocketSpawned()
    {
        StartCoroutine(SoundPlaying(_rocketFX));
    }

    private IEnumerator SoundPlaying(AudioClip audioClip)
    {
        yield return _wait;
        _audioSource.PlayOneShot(audioClip);
    }
}