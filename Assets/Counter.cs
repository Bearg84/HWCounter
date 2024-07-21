using UnityEngine;
using System;
using System.Collections;

public class Counter : MonoBehaviour
{
    private int _count;
    private bool _isRunning = false;
    private Coroutine _countingCoroutine;
    private WaitForSeconds _waitForSeconds;

    public float interval = 0.5f;
    public event Action<int> CountChanged;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(interval);
    }

    public void ToggleCounting()
    {
        if (_isRunning)
        {
            StopCounting();
        }
        else
        {
            StartCounting();
        }
    }

    private void StartCounting()
    {
        _countingCoroutine = StartCoroutine(Count());
        _isRunning = true;
    }

    private void StopCounting()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
        }

        _isRunning = false;
    }

    private IEnumerator Count()
    {
        while (true)
        {
            _count++;
            CountChanged?.Invoke(_count);
            yield return _waitForSeconds;
        }
    }
}