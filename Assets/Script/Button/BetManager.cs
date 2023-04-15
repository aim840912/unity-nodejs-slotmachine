using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BetManager : MonoBehaviour
{
    public Button PlusBtn;
    public Button MinusBtn;
    public Button MaxBtn;

    [SerializeField] TMP_Text _betValue;

    public int CurrentBet = 80;

    private void Update()
    {
        _betValue.text = $"{CurrentBet}";
    }

    public void AddBet()
    {
        if (CurrentBet + 80 <= PlayerManager.instance.Money)
            CurrentBet += 80;

    }

    public void MinusBet()
    {
        if (CurrentBet - 80 >= 0)
            CurrentBet -= 80;
    }

    public void MaxBet()
    {
        if (PlayerManager.instance.Money % 80 > 0)
        {
            int current = (int)(PlayerManager.instance.Money / 80);
            CurrentBet = 80 * current;
        }
        else
        {
            CurrentBet = 0;
        }

    }
}
