using System;
using UnityEngine;

[RequireComponent(typeof(FlappyMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(FlappyCollisionHandler))]
public class FlappyTerminator : MonoBehaviour
{
    private FlappyMover _flappyMover;
    private ScoreCounter _scoreCounter;
    private FlappyCollisionHandler _collisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _collisionHandler = GetComponent<FlappyCollisionHandler>();
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
