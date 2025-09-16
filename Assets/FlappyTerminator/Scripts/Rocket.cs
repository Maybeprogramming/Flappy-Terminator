using System.Collections;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private ObjectPool<Rocket> _pool;
    [SerializeField] private float _seconds;
    private WaitForSeconds _delayTimer;
    private float _speed;

    private void OnEnable()
    {
        _delayTimer = new WaitForSeconds(_seconds);
        StartCoroutine(LifeCountdown());
    }

    private void OnDisable()
    {
        _pool.PutObject(this);
    }

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        transform.position += transform.right * Time.deltaTime * _speed;
    }

    public void Init(ObjectPool<Rocket> pool, float speed)
    {
        _pool = pool;
        _speed = speed;
    }

    private IEnumerator LifeCountdown()
    {
        yield return _delayTimer;
        Debug.Log("Корутина завершилась");
        gameObject.SetActive(false);
    }
}