using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleText : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Text _toggleText;
    [SerializeField] private string _toggleOn;
    [SerializeField] private string _toggleOff;

    void Reset()
    {
        _toggle = this.GetComponent<Toggle>();
    }

    void Start()
    {
        _toggle.onValueChanged.AddListener(SetToggleText);
    }

    void SetToggleText(bool isOn)
    {
        if (isOn)
        {
            _toggleText.text = _toggleOn;
        }
        else
        {
            _toggleText.text = _toggleOff;
        }
    }
}
