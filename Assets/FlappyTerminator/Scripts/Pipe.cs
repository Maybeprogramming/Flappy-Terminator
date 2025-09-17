using System;
using UnityEngine;

public class Pipe : MonoBehaviour, IInteractable
{
    public event Action<Pipe> Released;

    internal void InvokeReleased()
    {
        Released?.Invoke(this);
    }
}