using UnityEngine;
using TMPro;

public class BetControl : ValueControl
{
    public TMP_Text[] EachBetGroup;

    private int GetPlayerMoney()
    {
        if (GameManager.instance._scenePattern == ScenePattern.ONLINE)
        {
            return PlayerManager.instance.PlayerData.Money;
        }
        else if (GameManager.instance._scenePattern == ScenePattern.SINGLE_GAME)
        {
            return PlayerPrefs.GetInt("playerMoney");
        }
        else
        {
            return 0;
        }
    }

    public override void Add()
    {
        if (CurrentValue + 80 <= GetPlayerMoney())
            CurrentValue += 80;

        CheckValue();
    }

    public override void Minus()
    {
        if (CurrentValue - 80 >= 0)
            CurrentValue -= 80;

        CheckValue();
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

        CheckValue();
    }

    protected override void CheckValue()
    {
        if (CurrentValue > GetPlayerMoney())
            CurrentValue = 0;

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
