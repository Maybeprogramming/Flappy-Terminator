using UnityEngine;
using UnityEngine.Pool;

public class MyPool<T> where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _conteiner;
    [SerializeField] private int _defaultCapacity;
    [SerializeField] private int _maxCapacity;
    [SerializeField] private bool _isCheckCollection;

    public ObjectPool<T> Pool;

    public void Init(T prefab, Transform conteiner, int copacity, int maxCopacity, bool isCheckCollection)
    {
        _prefab = prefab;
        _conteiner = conteiner;
        _defaultCapacity = copacity;
        _maxCapacity = maxCopacity;
        _isCheckCollection = isCheckCollection;

        Pool = new ObjectPool<T>
            (
                () => Create(),
                (entity) => Get(entity),
                (entity) => Put(entity),
                (entity) => GameObject.Destroy(entity.gameObject),
                _isCheckCollection,
                _defaultCapacity,
                _maxCapacity
            );
    }

    private void Put(T entity)
    {
        entity.gameObject.SetActive(false);
    }

    private void Get(T entity)
    {
        entity.gameObject.SetActive(true);
    }

    private T Create()
    {
        var instanceEntity = GameObject.Instantiate(_prefab);
        instanceEntity.transform.parent = _conteiner;
        return instanceEntity;
    }
}