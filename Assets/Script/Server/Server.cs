using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour
{
    public int WinMoney { get; private set; } = 0;
    public int[] SlotNumber = new int[9];

    private int _winLine = 8;
    private Board _board = new Board(0, 10);
    private CalcMultiple _calcMultiple = new CalcMultiple();

    [SerializeField] private ServerOnline serverOnline;

    public IEnumerator ServerCor(int inputValue)
    {
        StartCoroutine(serverOnline.GetBoardNum());

        yield return new WaitUntil(() => serverOnline.isGetData);

        SlotNumber = serverOnline.gameData.BoardNum;

    }

    public void ServerStep(int inputValue)
    {
        StartCoroutine(serverOnline.GetBoardNum());

        SlotNumber = serverOnline.gameData.BoardNum;

        // WinMoney = GetWinMoney(inputValue);

        // CalculatePlayerTotalMoney();
    }


    private int GetMultiple()
    {
        Debug.Log($"{_calcMultiple.GetMultiples(SlotNumber)}");// ! 查看倍率用

        return _calcMultiple.GetMultiples(SlotNumber);
    }

    private int GetWinMoney(int inputValue)
    {
        return GetMultiple() * inputValue - _winLine * inputValue;
    }

    private void CalculatePlayerTotalMoney()
    {
        PlayerManager.instance.PlayerMoney += WinMoney;
    }

}
