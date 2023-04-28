using UnityEngine;
using TMPro;
public class AutoControl : ValueControl
{
    public int AutoTime;

    public override void Add()
    {
        if (CurrentValue <= AutoTime)
            CurrentValue++;

        CheckCurrentValue();
    }

    public override void Minus()
    {
        if (CurrentValue > 0)
            CurrentValue--;

        CheckCurrentValue();
    }

    public override void Max()
    {
        CurrentValue = AutoTime;

        CheckCurrentValue();
    }

    public override void CheckCurrentValue()
    {
        if (CurrentValue > AutoTime)
            CurrentValue = AutoTime;

        ValueText.text = $"{CurrentValue}";
    }

    public override void SetZero()
    {
        CurrentValue = 0;
        ValueText.text = $"{CurrentValue}";
    }
}
