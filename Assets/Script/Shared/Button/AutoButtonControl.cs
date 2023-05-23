public class AutoButtonControl : ButtonControlBase
{
    private int SetMax = 100;

    public override void Add()
    {
        if (CurrentValue >= 0 && CurrentValue < 100)
            CurrentValue++;
    }

    public override void Minus()
    {
        if (CurrentValue > 0)
            CurrentValue--;
    }

    public override void Max()
    {
        CurrentValue = SetMax;
    }


    public void LoopOverOneTime()
    {
        if (CurrentValue > 0)
            CurrentValue--;

        SetCurrentValueText();
    }
}
