using UnityEngine;
using UnityEngine.Pool;

public class PoolEntities <T>: MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _collectionCheck;
    [SerializeField] private int _poolDefaultCapacity;
    [SerializeField] private int _poolMaxCapacity;
    
    private protected ObjectPool<T> Pool;

    private void Awake()
    {
        Initilize();
    }

    public T GetObject() => 
        Pool.Get();

    public void Release(T entity) =>
        entity.gameObject.SetActive(false);

    public void Initilize()
    {
        Pool = new ObjectPool<T>(() => Create(),
                    (entity) => Get(entity),
                    (entity) => Release(entity),
                    (entity) => Destroy(entity),
                    _collectionCheck,
                    _poolDefaultCapacity,
                    _poolMaxCapacity);
    }

    private T Create()
    {
        T instance = Instantiate(_prefab, Vector3.zero, Quaternion.identity);
        instance.transform.parent = _container.transform;
        return instance;
    }

    private protected void Get(T entity)
    {
        entity.gameObject.SetActive(true);
    }
}