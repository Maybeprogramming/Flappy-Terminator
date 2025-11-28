using System.Collections;
using UnityEngine;

public class Atacker : MonoBehaviour
{
    [SerializeField] private LaserSpawner _laserSpawner;
    [SerializeField] private float _delayBeforeAttack;
    [SerializeField] private float _delayBetweånAttack;

    private WaitForSeconds _waitBetweånAttak;
    private WaitForSeconds _waitBeforeAttack;
    private Coroutine _firing;

    private void Start()
    {
        _waitBetweånAttak = new WaitForSeconds(_delayBetweånAttack);
        _waitBeforeAttack = new WaitForSeconds(_delayBeforeAttack);        
    }

    private void OnEnable()
    {
        _firing = StartCoroutine(Firing());
    }

    private void OnDisable()
    {
        if (_firing != null)
            StopCoroutine(_firing);
    }

    public void Init(LaserSpawner laserSpawner)
    {
        _laserSpawner = laserSpawner;
    }

    private IEnumerator Firing()
    {
        yield return _waitBeforeAttack;

        while (enabled)
        {
            _laserSpawner.Spawn(transform);
            yield return _waitBetweånAttak;
        }
    }
}