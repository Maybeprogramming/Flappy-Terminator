using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemySoundFXPlayer : MonoBehaviour
{
    [Header("Звуки")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _laserFX;
    [SerializeField] private AudioClip _explouseFX;
    [SerializeField] private float _delayBeforePlay;

    [Header("Спавнеры")]
    [SerializeField] private LaserSpawner _laserSpawner;

    private WaitForSeconds _wait;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _laserSpawner.LaserSpawned += OnLaserSpawned;
    }

    private void OnDisable()
    {
        _laserSpawner.LaserSpawned -= OnLaserSpawned;
    }

    private void OnLaserSpawned()
    {
        if (enabled)
        {
            StartCoroutine(SoundPlaying(_laserFX));
        }
    }

    private IEnumerator SoundPlaying(AudioClip audioClip)
    {

            yield return _wait;
            _audioSource.PlayOneShot(audioClip);        
    }

    internal void Init(LaserSpawner laserSpawner)
    {
        _laserSpawner = laserSpawner;
        _laserSpawner.LaserSpawned += OnLaserSpawned;
    }
}
