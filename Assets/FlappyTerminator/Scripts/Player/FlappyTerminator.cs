using System;
using UnityEngine;

[RequireComponent(typeof(FlappyMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(CollisionHandler))]
public class FlappyTerminator : MonoBehaviour, ISoundPlayable
{
    private FlappyMover _flappyMover;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _collisionHandler;

    public event Action GameOver;
    public event Action SoundPlayed;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _flappyMover = GetComponent<FlappyMover>();
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
        if (interactable is Pipe || interactable is Laser)
        {
            GameOver?.Invoke();
            SoundPlayed?.Invoke();
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
