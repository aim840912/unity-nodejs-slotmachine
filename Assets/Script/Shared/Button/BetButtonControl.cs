using UnityEngine;
using TMPro;

public class BetButtonControl : ButtonControlBase
{
    public TMP_Text[] EachBetTextGroup;

    [SerializeField] private AutoButtonControl _autoControl;


    public override void Add()
    {
        if (CurrentValue + 80 <= PlayerMoney)
            CurrentValue += 80;
    }

    public override void Minus()
    {
        if (CurrentValue - 80 >= 0)
            CurrentValue -= 80;
    }

    public override void Max()
    {
        int maxMultiple = PlayerMoney / 80;

        if (maxMultiple > 0)
        {
            CurrentValue = 80 * maxMultiple;
        }
    }

    public override void ValueCheck()
    {
        if (CurrentValue > PlayerMoney)
        {
            OpenAlertPanel("YOUR BET MORE THAN YOUR MONEY");
            CurrentValue = 0;
        }
        _currentValueText.text = $"{CurrentValue}";
        SetEachBet();
    }

    private void SetEachBet()
    {
        for (int i = 0; i < EachBetTextGroup.Length; i++)
        {
            EachBetTextGroup[i].text = $"{CurrentValue / 8}";
        }
    }

    public override void SetZero()
    {
        CurrentValue = 0;
        _currentValueText.text = $"{CurrentValue}";

        SetEachBet();
    }

    private void ValueSet()// ! 修改
    {
        _currentValueText.text = $"{CurrentValue}";
        SetEachBet();
        _autoControl.ValueCheck();
    }

}
