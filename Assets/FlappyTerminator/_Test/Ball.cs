using System;
using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public event Action<Ball> OnDead;

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(2);
        OnDead?.Invoke(this);
    }
}
