using UnityEngine;
using UnityEngine.Pool;

public class PoolEntities<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private bool _collectionCheck;
    [SerializeField] private int _poolDefaultCapacity;
    [SerializeField] private int _poolMaxCapacity;

    private protected ObjectPool<T> Pool;

    private void Awake() => 
        Init();

    private void Init()
    {
        Pool = new ObjectPool<T>
            (
                    () => Create(),
                    (entity) => Get(entity),
                    (entity) => Release(entity),
                    (entity) => DestroyEntity(entity),
                    _collectionCheck,
                    _poolDefaultCapacity,
                    _poolMaxCapacity
            );
    }

    private void DestroyEntity(T entity) => 
        GameObject.Destroy(entity.gameObject);

    private void Release(T entity) =>
        entity.gameObject.SetActive(false);

    private T Create()
    {
        var instance = Instantiate(_prefab, Vector3.zero, Quaternion.identity);
        instance.transform.parent = _container.transform;
        return instance;
    }

    private void Get(T entity) => 
        entity.gameObject.SetActive(true);

    public void Clear() =>
        Pool.Clear();
}