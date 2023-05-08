using UnityEngine;
using TMPro;

public class BetButtonControl : ButtonControlBase
{
    [SerializeField] private TMP_Text[] _eachBetTextGroup;
    [SerializeField] private AutoButtonControl _autoControl;

    public override void Start()
    {
        base.Start();
        for (int i = 0; i < _button.Length; i++)
        {
            _button[i].onClick.AddListener(() => SetEachBetText());
        }
    }

    public override void Add()
    {
        if (_currentValue + 80 <= PlayerMoney)
            _currentValue += 80;
    }

    public override void Minus()
    {
        if (_currentValue - 80 >= 0)
            _currentValue -= 80;
    }

    public override void Max()
    {
        int maxMultiple = PlayerMoney / 80;

        if (maxMultiple > 0)
        {
            _currentValue = 80 * maxMultiple;
        }
    }

    public override void ValueCheck()
    {
        Debug.Log($"BetButtonControl ValueCheck()");
        if (_currentValue > PlayerMoney)
        {
            OpenAlertPanel("YOUR BET MORE THAN YOUR MONEY");
            _currentValue = 0;
        }
        SetCurrentValueText();
        SetEachBetText();
    }

    private void SetEachBetText()
    {
        for (int i = 0; i < _eachBetTextGroup.Length; i++)
        {
            _eachBetTextGroup[i].text = $"{_currentValue / 8}";
        }
    }
}
