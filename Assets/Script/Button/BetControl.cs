using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BetControl : MonoBehaviour
{
    [SerializeField] TMP_Text _betValue;

    public int CurrentBet { get; private set; } = 0;
    public TMP_Text[] EachBetGroup;

    public void AddBet()
    {
        if (CurrentBet + 80 <= PlayerManager.instance.Money)
            CurrentBet += 80;

        UpdateBetNumber();
    }

    public void MinusBet()
    {
        if (CurrentBet - 80 >= 0)
            CurrentBet -= 80;

        UpdateBetNumber();
    }

    public void MaxBet()
    {
        if (PlayerManager.instance.Money / 80 > 0)
        {
            int current = (int)(PlayerManager.instance.Money / 80);
            CurrentBet = 80 * current;
        }
        else
        {
            CurrentBet = 0;
        }

        UpdateBetNumber();
    }

    void UpdateBetNumber()
    {
        if (CurrentBet > PlayerManager.instance.Money)
            CurrentBet = 0;

        _betValue.text = $"{CurrentBet}";

        for (int i = 0; i < EachBetGroup.Length; i++)
        {
            EachBetGroup[i].text = $"{GetEachBet()}";
        }
    }

    public int GetEachBet()
    {
        return CurrentBet / 8;
    }
}
