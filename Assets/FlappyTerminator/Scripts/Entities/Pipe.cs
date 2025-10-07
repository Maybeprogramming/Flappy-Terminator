using System;

public class Pipe : Entity, IInteractable
{
    public event Action<Pipe> Released;

    public void Interacted()
    {
        Released?.Invoke(this);
    }

    public override void Reset()
    {
        Released?.Invoke(this);
    }
}