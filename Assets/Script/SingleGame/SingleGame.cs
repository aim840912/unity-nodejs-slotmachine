using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SingleGame : MonoBehaviour, IGameMode
{
    public int WinMoney { get; set; }
    public int[] SlotNumber { get; set; } = new int[9];
    public int PlayerMoney { get; set; }

    [SerializeField] private TMP_Text _betInputValue;

    readonly int _minBoardNumber = 0;
    readonly int _maxBoardNumber = 10;
    private CalcMultiple _calcMultiple = new CalcMultiple();


    public IEnumerator GetServerData()
    {
        GenerateGameBoard();

        CalcMoney();

        yield return null;
    }

    void GenerateGameBoard()
    {
        for (var i = 0; i < SlotNumber.Length; i++)
        {
            SlotNumber[i] = Random.Range(_minBoardNumber, _maxBoardNumber);
        }
    }

    void CalcMoney()
    {
        int _currentMoney = GetPlayerMoney();

        WinMoney = GetMultiple() * GetInputValue() - 8 * GetInputValue();

        _currentMoney += WinMoney;

        SetPlayerMoney(_currentMoney);
    }

    int GetMultiple()
    {
        int multiple = _calcMultiple.GetMultiples(SlotNumber);
        Debug.Log($"{multiple}");

        return multiple;
    }

    int GetInputValue()
    {
        return int.Parse(_betInputValue.text);
    }

    int GetPlayerMoney()
    {
        if (!PlayerPrefs.HasKey("playerMoney"))
        {
            PlayerPrefs.SetInt("playerMoney", 10000);
        }

        return PlayerPrefs.GetInt("playerMoney");
    }

    void SetPlayerMoney(int money)
    {
        PlayerPrefs.SetInt("playerMoney", money);
    }
}
