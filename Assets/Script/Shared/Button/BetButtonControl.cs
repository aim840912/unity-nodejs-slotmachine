using UnityEngine;
using TMPro;

public class BetButtonControl : ButtonControlBase
{
    [SerializeField] private TMP_Text[] _eachBetTextGroup;

    public override void Add()
    {
        if (CurrentValue + 80 <= GetPlayerMoney())
            CurrentValue += 80;
    }

    public override void Minus()
    {
        if (CurrentValue - 80 >= 0)
            CurrentValue -= 80;
    }

    public override void Max()
    {
        int maxMultiple = GetPlayerMoney() / 80;

        if (maxMultiple > 0)
        {
            CurrentValue = 80 * maxMultiple;
        }
    }

    public bool ValueCheck()
    {
        if (CurrentValue > GetPlayerMoney())
        {
            OpenAlertPanel("YOUR BET MORE THAN YOUR MONEY");
            CurrentValue = 0;

            SetCurrentValueText();
            return false;
        }

        return true;
    }

    protected override void SetCurrentValueText()
    {
        base.SetCurrentValueText();
        SetEachBetText();
    }

    private void SetEachBetText()
    {
        for (int i = 0; i < _eachBetTextGroup.Length; i++)
        {
            _eachBetTextGroup[i].text = $"{CurrentValue / 8}";
        }
    }
}
