using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server
{
    public int WinMoney { get; private set; } = 0;

    private int[] _slotNumber = new int[9];
    private int _multiple;
    private int _winLine = 8;
    private Board _board = new Board(0, 10);
    private CalcMultiple _calcMultiple = new CalcMultiple();


    public void ServerStep(int inputValue)
    {
        _slotNumber = _board.GenerateNumber();
        foreach (var item in _slotNumber)
        {
            Debug.Log($"{item}");
        }

        _multiple = GetMultiple();

        WinMoney = GetWinMoney(inputValue);
    }


    private int GetMultiple()
    {
        Debug.Log($"{_calcMultiple.GetMultiples(_slotNumber)}");

        return _calcMultiple.GetMultiples(_slotNumber);

    }

    private int GetWinMoney(int inputValue)
    {
        return GetMultiple() * inputValue - _winLine * inputValue;
    }

    public int[] GetBoard()
    {
        return _slotNumber;
    }

}
