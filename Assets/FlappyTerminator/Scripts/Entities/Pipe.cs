using System;
using UnityEngine;

public class Pipe : MonoBehaviour, IInteractable
{
    public event Action<Pipe> Released;

    public void Interacted()
    {
        Released?.Invoke(this);
    }
}