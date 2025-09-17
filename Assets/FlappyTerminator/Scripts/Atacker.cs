using System.Collections;
using UnityEngine;

public class Atacker : MonoBehaviour
{
    [SerializeField] private LaserSpawner _laserSpawner;
    [SerializeField] private float _delayBeforeAttack;
    [SerializeField] private float _delayBetwe�nAttack;

    private WaitForSeconds _waitBetwe�nAttak;
    private WaitForSeconds _waitBeforeAttack;

    private void Start()
    {
        _waitBetwe�nAttak = new WaitForSeconds(_delayBetwe�nAttack);
        _waitBeforeAttack = new WaitForSeconds(_delayBeforeAttack);

        StartCoroutine(Firing());
    }

    public void Init(LaserSpawner laserSpawner)
    {
        _laserSpawner = laserSpawner;
    }

    private IEnumerator Firing()
    {
        yield return _delayBetwe�nAttack;

        while (enabled)
        {
            _laserSpawner.Spawn(transform);
            yield return _waitBetwe�nAttak;
        }
    }
}