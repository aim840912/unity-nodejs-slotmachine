using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BetControl : ValueControl
{
    public TMP_Text[] EachBetGroup;
    [SerializeField] private Button[] _button;


    private void Start()
    {
        for (int i = 0; i < _button.Length; i++)
        {
            _button[i].onClick.AddListener(() => SetValueToText());
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
        if (GetPlayerMoney() / 80 > 0)
        {
            int current = (GetPlayerMoney() / 80);
            CurrentValue = 80 * current;
        }
        else
        {
            CurrentValue = 0;
        }
    }

    public override void SetValueToText()
    {
        if (CurrentValue > GetPlayerMoney())
            Max();

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

}
