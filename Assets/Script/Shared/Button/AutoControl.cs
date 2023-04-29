using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AutoControl : ValueControl
{
    public int AutoMaxTime;
    [SerializeField] private Button[] _button;
    [SerializeField] private BetControl _betControl;

    private void Start()
    {
        for (int i = 0; i < _button.Length; i++)
        {
            _button[i].onClick.AddListener(() => SetValueToText());
        }
    }

    public override void Add()
    {
        if (CurrentValue <= AutoMaxTime)
            CurrentValue++;
    }

    public override void Minus()
    {
        if (CurrentValue > 0)
            CurrentValue--;
    }

    public override void Max()
    {
        AutoMaxTime = CountMax(_betControl.CurrentValue);
        CurrentValue = AutoMaxTime;
    }

    public override void SetValueToText()
    {
        if (CurrentValue > AutoMaxTime)
            Max();

        ValueText.text = $"{CurrentValue}";
    }

    public override void SetZero()
    {
        CurrentValue = 0;
        ValueText.text = $"{CurrentValue}";
    }

    private int CountMax(int betMoney)
    {
        int playerMoney = PlayerManager.instance.PlayerData.Money;

        return (int)playerMoney / betMoney;
    }
}
