using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class ButtonControlBase : MonoBehaviour
{
    [SerializeField] protected TMP_Text _currentValueText;
    [SerializeField] protected Button[] _button;
    [SerializeField] protected GameObject _alertPanel;
    [SerializeField] protected TMP_Text _alertMessage;
    protected int _currentValue = 0;
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

    public int PlayerMoney
    {
        get
        {
            return PlayerManager.instance.PlayerData.Money;
        }
    }

    public virtual void Start()
    {
        GameManager.Instance.SpinEvent += ValueCheck;

        for (int i = 0; i < _button.Length; i++)
        {
            _button[i].onClick.AddListener(() => SetCurrentValueText());
        }
    }

    public abstract void Add();
    public abstract void Minus();
    public abstract void Max();
    public void SetZero() => _currentValue = 0;

    public abstract void ValueCheck();

    protected void SetCurrentValueText() => _currentValueText.text = $"{_currentValue}";

    protected void OpenAlertPanel(string alertMessage)
    {
        _alertPanel.SetActive(true);
        _alertMessage.text = alertMessage;
    }
}