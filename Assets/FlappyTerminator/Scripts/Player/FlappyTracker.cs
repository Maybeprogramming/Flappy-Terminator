using UnityEngine;

public class FlappyTracker : MonoBehaviour
{
    [SerializeField] private FlappyTerminator _flappyTerminator;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _flappyTerminator.transform.position.x + _xOffset;
        transform.position = position;
    }
}
