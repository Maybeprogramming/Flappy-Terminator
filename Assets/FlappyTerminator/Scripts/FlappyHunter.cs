using System;
using UnityEngine;

[RequireComponent(typeof(FlappyMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(FlappyCollisionHandler))]
public class FlappyHunter : MonoBehaviour
{
    private FlappyMover _flappyMover;
    private ScoreCounter _scoreCounter;
    private FlappyCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<FlappyCollisionHandler>();
        _flappyMover = GetComponent<FlappyMover>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Pipe)
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
