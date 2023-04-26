using UnityEngine;
using TMPro;
public class AutoControl : ValueControl
{
    public int AutoTime;

    public override void Add()
    {
        if (CurrentValue <= AutoTime)
            CurrentValue++;

        CheckValue();
    }

    public override void Minus()
    {
        if (CurrentValue >= 0)
            CurrentValue--;

        CheckValue();
    }

    public override void Max()
    {
        CurrentValue = 10;

        CheckValue();
    }

    protected override void CheckValue()
    {
        if (CurrentValue > AutoTime)
            CurrentValue = 0;

        ValueText.text = $"{CurrentValue}";
    }

    public override void SetZero()
    {
        CurrentValue = 0;
        ValueText.text = $"{CurrentValue}";
    }
}
