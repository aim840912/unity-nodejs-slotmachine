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

    public override void ValueCheck()
    {
        if (CurrentValue < 0)
        {
            OpenAlertPanel("YOUR AUTO LESS THAN 0");
            CurrentValue = 0;
        }
        SetCurrentValueText();
    }

    public void LoopOneTime()
    {
        if (CurrentValue > 0)
        {
            CurrentValue--;
            ValueCheck();
        }
    }
}
