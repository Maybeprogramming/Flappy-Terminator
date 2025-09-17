using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Ïóë:")]
    [SerializeField] private Transform _container;
    [SerializeField] private T _prefab;

    private Queue<T> _pool;
    private List<T> _listEntityPool;

    public IEnumerable<T> PooledObjects => _pool;
    public int Count => _listEntityPool.Count();
    public int ActiveCount => Count == 0 ? 0 : _listEntityPool.Where(e => e.gameObject.activeSelf == true).Count();

    private void Awake()
    {
        _pool = new Queue<T>();
        _listEntityPool = new List<T>();
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            var entity = Instantiate(_prefab);
            _pool.Enqueue(entity);
            _listEntityPool.Add(entity);

            entity.transform.parent = _container;

            return entity;
        }

        return _pool.Dequeue();
    }

    public void PutObject(T entity)
    {
        _pool.Enqueue(entity);
        entity.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}