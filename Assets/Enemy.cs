using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ObjectPool<Enemy> _pool;
    [SerializeField] private float _xOffset;
    [SerializeField] private Transform _mainCamera;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);

        if (collision.transform.TryGetComponent<Rocket>(out _))
        {
            _pool.PutObject(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Rocket>(out _))
        {
            _pool.PutObject(this);
        }
    }

    public void Init(ObjectPool<Enemy> pool, Transform mainCamera)
    {
        _pool = pool;
        _mainCamera = mainCamera;
    }


    private void Update()
    {
        var position = transform.position;
        position.x = _mainCamera.transform.position.x + _xOffset;
        transform.position = position;
    }
}