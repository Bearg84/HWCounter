using UnityEngine;
using TMPro;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private Counter counter;

    private void OnEnable()
    {
        counter.CountChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        counter.CountChanged -= UpdateDisplay;
    }

    private void UpdateDisplay(int newCount)
    {
        numberText.text = newCount.ToString();
    }
}