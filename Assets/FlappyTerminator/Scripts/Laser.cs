using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed;

    private ObjectPool<Laser> _pool;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rocket>(out _) || collision.gameObject.TryGetComponent<FlappyTerminator>(out _))
        {
            _pool.PutObject(this);
        }
    }

    private void Update()
    {
        Moving();
    }
    private void Moving()
    {
        transform.position += (transform.right * Time.deltaTime * _speed) * -1f;
    }

    public void Init(ObjectPool<Laser> pool)
    {
        _pool = pool;
    }
}