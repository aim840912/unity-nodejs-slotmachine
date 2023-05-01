using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BetButtonControl : ValueControl
{
    public TMP_Text[] EachBetGroup;
    [SerializeField] private Button[] _button;
    [SerializeField] private AutoButtonControl _autoControl;

    private void Start()
    {
        for (int i = 0; i < _button.Length; i++)
        {
            _button[i].onClick.AddListener(() => ValueSet());
        }
    }

    private int GetPlayerMoney()
    {
        return PlayerManager.instance.PlayerData.Money;
    }

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

    public override void ValueCheck()
    {
        if (CurrentValue > GetPlayerMoney())
        {
            CurrentValue = 0;
        }

        ValueText.text = $"{CurrentValue}";
        SetEachBet();
    }

    private void SetEachBet()
    {
        for (int i = 0; i < EachBetGroup.Length; i++)
        {
            EachBetGroup[i].text = $"{CurrentValue / 8}";
        }
    }

    public override void SetZero()
    {
        CurrentValue = 0;
        ValueText.text = $"{CurrentValue}";

        SetEachBet();
    }

    private void ValueSet()
    {
        ValueText.text = $"{CurrentValue}";
        SetEachBet();
        _autoControl.ValueCheck();
    }

}
