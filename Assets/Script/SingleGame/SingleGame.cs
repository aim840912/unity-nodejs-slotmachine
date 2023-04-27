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

        SaveData();
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
        int _currentMoney = PlayerManager.instance.PlayerData.Money;

        WinMoney = GetMultiple() * GetInputValue() / 8 - GetInputValue();

        _currentMoney += WinMoney;

        SaveManager.instance.gameData.Money = _currentMoney;

        PlayerManager.instance.PlayerData.Money = _currentMoney;

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

    void SaveData()
    {
        SaveManager.instance.gameData.BoardNum = this.SlotNumber;
        SaveManager.instance.SaveGame();
    }


}
