using UnityEngine;
using TMPro;

public class BetButtonControl : ButtonControlBase
{
    [SerializeField] private TMP_Text[] _eachBetTextGroup;

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

        SetCurrentValueText();
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
