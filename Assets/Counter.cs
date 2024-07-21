using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _count;
    private bool _isRunning = false;
    private Coroutine _countingCoroutine;
    private WaitForSeconds _waitForSeconds;

    private float _interval = 0.5f;

    public event Action<int> CountChanged;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_interval);
    }

    public void SetInterval(float interval)
    {
        if (interval > 0)
        {
            _interval = interval;
            _waitForSeconds = new WaitForSeconds(_interval);
        }
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