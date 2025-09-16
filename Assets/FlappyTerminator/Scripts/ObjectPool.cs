using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool <T>: MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private T _prefab;

    private Queue<T> _pool;

    public IEnumerable<T> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<T>();        
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            var entity = Instantiate(_prefab);
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