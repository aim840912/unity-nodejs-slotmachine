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
        if (CurrentBet + 80 <= PlayerManager.instance.PlayerData.Money)
            CurrentBet += 80;

        CheckBetNumber();
    }

    public void MinusBet()
    {
        if (CurrentBet - 80 >= 0)
            CurrentBet -= 80;

        CheckBetNumber();
    }

    public void MaxBet()
    {
        if (PlayerManager.instance.PlayerData.Money / 80 > 0)
        {
            int current = (int)(PlayerManager.instance.PlayerData.Money / 80);
            CurrentBet = 80 * current;
        }
        else
        {
            CurrentBet = 0;
        }

        CheckBetNumber();
    }

    void CheckBetNumber()
    {
        if (CurrentBet > PlayerManager.instance.PlayerData.Money)
            CurrentBet = 0;

        _betValue.text = $"{CurrentBet}";

        SetEachBet();
    }

    public void SetEachBet()
    {
        for (int i = 0; i < EachBetGroup.Length; i++)
        {
            EachBetGroup[i].text = $"{CurrentBet / 8}";
        }
    }
}
