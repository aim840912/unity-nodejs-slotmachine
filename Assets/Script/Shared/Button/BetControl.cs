using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BetControl : MonoBehaviour
{
    [SerializeField] TMP_Text _betValue;
    public int CurrentBet { get; private set; } = 0;
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

    public void AddBet()
    {
        if (CurrentBet + 80 <= GetPlayerMoney())
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
        if (GetPlayerMoney() / 80 > 0)
        {
            int current = (GetPlayerMoney() / 80);
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
        if (CurrentBet > GetPlayerMoney())
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

    public void SetZero()
    {
        CurrentBet = 0;
        _betValue.text = $"{CurrentBet}";

        SetEachBet();
    }

    public int GetBetInputValue()
    {
        return int.Parse(_betValue.text);
    }
}
