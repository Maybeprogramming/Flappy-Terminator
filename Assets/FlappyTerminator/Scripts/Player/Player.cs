using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(CollisionHandler))]
public class Player : MonoBehaviour, ISoundEffector
{
    private PlayerMover _flappyMover;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _collisionHandler;

    public event Action GameOver;
    public event Action SoundPlaying;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _flappyMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += OnProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= OnProcessCollision;
    }

    private void OnProcessCollision(IInteractable interactable)
    {
        if (interactable is Laser)
        {
            GameOver?.Invoke();
            SoundPlaying?.Invoke();
        }
        else if(interactable is ScoreZone) 
        {
            _scoreCounter.Add();
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _flappyMover.Reset();
    }
}
