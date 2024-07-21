using UnityEngine;
using TMPro;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberText;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= UpdateDisplay;
    }

    private void UpdateDisplay(int newCount)
    {
        _numberText.text = newCount.ToString();
    }
}