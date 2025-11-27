using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolEntities<T> : MonoBehaviour where T: Entity
{
    [SerializeField] private T _prefab;
    [SerializeField] private bool _collectionCheck;
    [SerializeField] private int _poolDefaultCapacity;
    [SerializeField] private int _poolMaxCapacity;

    private protected Vector3 Position => transform.position;
    private protected ObjectPool<T> Pool;
    
    private Transform _container;
    [SerializeField] private List<T> _spawenedEntities;

    private void Awake() => 
        Init();

    private void Init()
    {
        _spawenedEntities = new List<T>();

        CreateParentConteiner();

        Pool = new ObjectPool<T>
            (
                    () => Create(),
                    (entity) => Get(entity),
                    (entity) => Put(entity),
                    (entity) => GameObject.Destroy(entity.gameObject),
                    _collectionCheck,
                    _poolDefaultCapacity,
                    _poolMaxCapacity
            );
    }

    private void Put(T entity)
    {
        _spawenedEntities.Remove(entity);
        entity.gameObject.SetActive(false);
    }

    private void Get(T entity)
    {
        _spawenedEntities.Add(entity);
        entity.gameObject.SetActive(true);
    }

    private T Create()
    {
        var instance = Instantiate(_prefab, Vector3.zero, Quaternion.identity);
        instance.transform.parent = _container;
        return instance;
    }

    private void CreateParentConteiner()
    {
        var conteiner = new GameObject($"Pool: [{_prefab.name}]");
        _container = conteiner.transform;
    }

    public void Reset()
    {
        if (_spawenedEntities.Count > 0)
        {
            for (int i = 0; i < _spawenedEntities.Count; i++)
            {
                _spawenedEntities[i].Reset();
            }

            _spawenedEntities.Clear();
        }
    }
}