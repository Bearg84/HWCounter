using UnityEngine;
using UnityEngine.UI;

public class CounterButton : MonoBehaviour
{
    public Counter counter;
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(counter.ToggleCounting);
    }
}