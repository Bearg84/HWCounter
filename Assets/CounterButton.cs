using UnityEngine;
using UnityEngine.UI;

public class CounterButton : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _counter.ToggleCounting();
    }
}