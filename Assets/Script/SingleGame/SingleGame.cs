using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SingleGame : MonoBehaviour, IGameMode
{
    int _currentMoney;
    public int WinMoney { get; set; }
    public int[] SlotNumber { get; set; } = new int[9];
    public int InputValue
    {
        get
        {
            return int.Parse(_betInputValue.text);
        }
    }
    [SerializeField] private TMP_Text _betInputValue;
    int PlayerMoney
    {
        get
        {
            return PlayerPrefs.HasKey("playerMoney") ? PlayerPrefs.GetInt("playerMoney") : 10000;
        }
        set
        {
            PlayerPrefs.SetInt("playerMoney", value);
        }
    }

    readonly int _minBoardNumber = 0;
    readonly int _maxBoardNumber = 10;
    CalcMultiple _calcMultiple = new CalcMultiple();


    public IEnumerator GetServerData()
    {
        PlayerPrefs.SetInt("playerMoney", 10000);
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
        WinMoney = GetMultiple() * InputValue - 8 * InputValue;

        PlayerMoney += WinMoney;
    }

    int GetMultiple()
    {
        int multiple = _calcMultiple.GetMultiples(SlotNumber);
        Debug.Log($"{multiple}");

        return multiple;
    }
}
