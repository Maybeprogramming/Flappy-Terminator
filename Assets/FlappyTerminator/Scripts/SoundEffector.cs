using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    [SerializeField] private Sounds _sound;

    private ISoundPlayable _soundEffector;
    private SoundPlayer _soundPlayer;

    private void OnDestroy() => 
        _soundEffector.SoundPlayed -= OnPlaySound;

    public void Init(SoundPlayer soundPlayer, ISoundPlayable soundEffector)
    {
        _soundEffector = soundEffector;
        _soundPlayer = soundPlayer;
        _soundEffector.SoundPlayed += OnPlaySound;
    }

    private void OnPlaySound() =>
        _soundPlayer.PlayOneShot(_sound);
}