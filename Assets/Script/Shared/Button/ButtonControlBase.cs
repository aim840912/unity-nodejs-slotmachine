using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class ButtonControlBase : MonoBehaviour
{
    [SerializeField] protected TMP_Text ValueText;
    [SerializeField] protected Button[] _button;
    private int _currentValue = 0;
    public int CurrentValue
    {
        get
        {
            return _currentValue >= 0 ? _currentValue : 0;
        }
        set
        {
            _currentValue = value;
        }
    }

    public virtual void Start()
    {
        for (int i = 0; i < _button.Length; i++)
        {
            _button[i].onClick.AddListener(() => SetText());
        }
    }

    public abstract void Add();
    public abstract void Minus();
    public abstract void Max();
    public abstract void SetZero();
    public abstract void ValueCheck();

    public virtual void SetText()
    {
        ValueText.text = $"{CurrentValue}";
    }

}