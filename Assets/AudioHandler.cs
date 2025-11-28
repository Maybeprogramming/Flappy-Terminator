using UnityEngine;

[RequireComponent(typeof(AudioProvider))]
public class AudioHandler : MonoBehaviour
{
    [SerializeField] private float _volumeMax;
    private AudioProvider _audioProvider;

    private void Awake()
    {
        _audioProvider = GetComponent<AudioProvider>();
    }

    public void OnGameOver()
    {
        _audioProvider.SetVolume(_volumeMax);
        _audioProvider.Play(AudioClips.GameOver);
    }

    public void OnLaserShoot()
    {
        _audioProvider.SetVolume(0.3f);
        _audioProvider.Play(AudioClips.Laser);
    }

    public void OnRocketShoot()
    {
        _audioProvider.SetVolume(0.3f);
        _audioProvider.Play(AudioClips.Rocket);
    }

    public void OnExplouse()
    {
        _audioProvider.SetVolume(0.3f);
        _audioProvider.Play(AudioClips.Explouse);
    }
}