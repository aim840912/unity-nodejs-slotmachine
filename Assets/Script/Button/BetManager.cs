using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BetManager : MonoBehaviour
{
    public Button PlusBtn;
    public Button MinusBtn;
    public Button MaxBtn;

    public int CurrentBet = 80;

    public int AddBet()
    {
        if (CurrentBet + 80 > PlayerManager.instance.Money)
            return CurrentBet;
        else
            return CurrentBet + 80;

    }

    public int MinusBet()
    {
        if (CurrentBet - 80 > 0)
            return CurrentBet;
        else
            return CurrentBet - 80;
    }

    public int MaxBet()
    {
        if (PlayerManager.instance.Money % 80 > 0)
        {
            int current = PlayerManager.instance.Money / 80;
            return current * 80;
        }
        else
        {
            return PlayerManager.instance.Money;
        }
    }
}
