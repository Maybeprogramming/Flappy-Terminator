using System;
using UnityEngine;
using UnityEngine.Pool;

public class PoolEntities <T>: MonoBehaviour where T : MonoBehaviour
{
    [Header("Базовые настройки")]
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;

    private protected ObjectPool<T> Pool;

    public event Action<int, int, int> Informing;

    [field: SerializeField] public int PoolDefaultCapacity { get; private set; }
    [field: SerializeField] public int PoolMaxCapacity { get; private set; }

    public int SpawnedEntities { get; private set; }
    public int CreatedEntities => Pool.CountAll;
    public int ActiveEntities => Pool.CountActive;

    private void Awake()
    {
        SpawnedEntities = 0;
        PoolInit();
    }

    private void Start() =>
        DoInforming(SpawnedEntities, CreatedEntities, ActiveEntities);

    public void Reset()
    {
        Pool.Clear();
    }

    private protected virtual void PoolInit() { }

    private protected T Create()
    {
        T instance = Instantiate(_prefab, Vector3.zero, Quaternion.identity);
        instance.transform.parent = _container.transform;
        return instance;
    }

    private protected void PutEntity(T entity)
    {
        entity.gameObject.SetActive(true);
        SpawnedEntities++;
    }

    private void DoInforming(int spawenedEntities, int createdEntities, int activeEntities) =>
    Informing?.Invoke(spawenedEntities, createdEntities, activeEntities);
}