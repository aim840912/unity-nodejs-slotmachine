using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour, IGameMode
{
    public int WinMoney { get; set; }
    public int[] SlotNumber { get; set; } = new int[9];
    [SerializeField] private ServerData _serverData;

    public IEnumerator GetServerData()
    {
        StartCoroutine(_serverData.PostServerData());

        yield return new WaitUntil(() => _serverData.HasGetData == true);

        SlotNumber = _serverData.ServerReturnData.Arr;
        WinMoney = _serverData.ServerReturnData.WinMoney;
    }
}
