using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class AutoButtonControl : ButtonControlBase
{
    [SerializeField] private BetButtonControl _betControl;

    public override void Start()
    {
        base.Start();
        // for (int i = 0; i < _button.Length; i++)
        // {
        //     _button[i].onClick.AddListener(() => SetGameMangerAuto());
        // }
    }

    public override void Add()
    {
        if (CurrentValue < MaxMultiple())
            CurrentValue++;
    }

    public override void Minus()
    {
        if (CurrentValue > 0)
            CurrentValue--;
    }

    public override void Max()
    {
        CurrentValue = MaxMultiple();
    }

    public override void ValueCheck()
    {
        if (CurrentValue > MaxMultiple())
        {
            OpenAlertPanel("YOUR AUTO MORE THAN YOUR MONEY");
            CurrentValue = 0;
        }
        // SetGameMangerAuto();
        SetCurrentValueText();
    }

    // private void SetGameMangerAuto()
    // {
    //     GameManager.Instance.AutoTime = CurrentValue;

    //     Debug.Log(GameManager.Instance.AutoTime);
    // }

    private int MaxMultiple()
    {
        int betMoney = _betControl.CurrentValue;

        if (PlayerMoney != 0 && betMoney != 0)
            return (int)PlayerMoney / betMoney;
        else
            return 0;
    }
}
