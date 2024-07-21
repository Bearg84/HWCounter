using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class NumberIncreaser : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    private int count;
    private bool isRunning = false;
    private Coroutine countingCoroutine;

    public void ButtonClick()
    {
        if (isRunning == true)
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
        StopCoroutine(countingCoroutine);
        isRunning = false;
    }

    private IEnumerator Count()
    {
        while (true)
        {
            count++;
            numberText.text = count.ToString();
            Debug.Log(count);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Start()
    {
        numberText.text = count.ToString();
    }
}