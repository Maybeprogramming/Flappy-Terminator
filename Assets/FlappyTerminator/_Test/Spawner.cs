using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ball _prefab;
    [SerializeField] private Transform _conteiner;

    private MyPool<Ball> _myPool;
    private Ball _ball;

    private void Awake()
    {
        _myPool = new MyPool<Ball>();
        _myPool.Init(_prefab, _conteiner, 5, 10, true);
    }

    public void Spawn()
    {
        _ball = _myPool.Pool.Get();
        _ball.OnDead += OnRelease;
        Debug.Log($"{_myPool.Pool.CountActive} - активных");
    }

    private void OnRelease(Ball ball)
    {
        _myPool.Pool.Release(ball);
    }


    public void Clear()
    {
        //Destroy(_ball.gameObject);
        _myPool.Pool.Clear();
        //Debug.Log($"{_myPool.Pool.CountInactive} - неактивных");
        //Debug.Log($"{_myPool.Pool.CountAll} - всех");
    }
}