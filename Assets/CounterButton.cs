using UnityEngine;
using UnityEngine.UI;

public class CounterButton : MonoBehaviour
{
    [SerializeField] private Counter counter;
    [SerializeField] private Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        counter.ToggleCounting();
    }
}