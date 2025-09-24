using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    [SerializeField] private Sounds _sound;

    private ISoundable _soundEffector;
    private SoundPlayer _soundPlayer;

    private void OnDestroy() => 
        _soundEffector.SoundPlaying -= OnPlaySound;

    public void Init(SoundPlayer soundPlayer, ISoundable soundEffector)
    {
        _soundEffector = soundEffector;
        _soundPlayer = soundPlayer;
        _soundEffector.SoundPlaying += OnPlaySound;
    }

    private void OnPlaySound() =>
        _soundPlayer.PlayOneShot(_sound);
}