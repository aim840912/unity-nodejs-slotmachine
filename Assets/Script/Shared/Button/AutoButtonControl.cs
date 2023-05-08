using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AutoButtonControl : ButtonControlBase
{
    [SerializeField] private BetButtonControl _betControl;

    public override void Add()
    {
        if (_currentValue < MaxMultiple())
            _currentValue++;
    }

    public override void Minus()
    {
        if (_currentValue > 0)
            _currentValue--;
    }

    public override void Max()
    {
        _currentValue = MaxMultiple();
    }

    public override void ValueCheck()
    {
        Debug.Log($"AutoButtonControl ValueCheck()");
        if (_currentValue > MaxMultiple())
        {
            OpenAlertPanel("YOUR AUTO MORE THAN YOUR MONEY");
            _currentValue = 0;
        }
        SetCurrentValueText();
    }

    private int MaxMultiple()
    {
        int betMoney = _betControl.CurrentValue;

        if (PlayerMoney != 0 && betMoney != 0)
            return (int)PlayerMoney / betMoney;
        else
            return 0;
    }
}
