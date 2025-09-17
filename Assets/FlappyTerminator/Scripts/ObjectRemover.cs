using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Pipe>(out Pipe pipe))
        {
            pipe.InvokeReleased();
        }
    }
}
