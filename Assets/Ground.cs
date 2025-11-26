using UnityEngine;

public class Ground : MonoBehaviour, IDamageProvider
{
    [SerializeField] private int _damage;
    public int Damage => _damage;
}