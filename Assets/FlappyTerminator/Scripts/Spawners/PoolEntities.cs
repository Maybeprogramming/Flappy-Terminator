using UnityEngine;
using UnityEngine.Pool;

public class PoolEntities<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private bool _collectionCheck;
    [SerializeField] private int _poolDefaultCapacity;
    [SerializeField] private int _poolMaxCapacity;

    private protected Vector3 Position => transform.position;
    private protected ObjectPool<T> Pool;
    
    private Transform _container;

    private void Awake() => 
        Init();

    private void Init()
    {
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
        entity.gameObject.SetActive(false);
    }

    private void Get(T entity)
    {
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
        Pool.Clear();
    }
}