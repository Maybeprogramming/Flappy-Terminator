using System;
using UnityEngine;

[Serializable]
public class PoolConfig: MonoBehaviour
{
    //[SerializeField] private Component _prefab;
    [SerializeField] private bool _collectionCheck;
    [SerializeField] private int _poolDefaultCapacity;
    [SerializeField] private int _poolMaxCapacity;

    //public Component Prefab => _prefab;
    public bool CollectionCheck => _collectionCheck;
    public int DefaultCapacity => _poolDefaultCapacity;
    public int MaxCapacity => _poolMaxCapacity;
}
