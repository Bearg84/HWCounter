using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
    private int count;
    private bool isRunning = false;
    private Coroutine countingCoroutine;
    public float interval = 0.5f; // Интервал времени в секундах

    public delegate void OnCountChanged(int newCount);
    public event OnCountChanged CountChanged;

    public void ToggleCounting()
    {
        if (isRunning)
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
        countingCoroutine = StartCoroutine(Count());
        isRunning = true;
    }

    private void StopCounting()
    {
        if (countingCoroutine != null)
        {
            StopCoroutine(countingCoroutine);
        }
        isRunning = false;
    }

    private IEnumerator Count()
    {
        while (true)
        {
            count++;
            CountChanged?.Invoke(count);
            yield return new WaitForSeconds(interval);
        }
    }

    public int GetCount()
    {
        return count;
    }
}