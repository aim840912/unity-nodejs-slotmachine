using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : MonoBehaviour
{
    public int WinMoney;
    public int[] SlotNumber = new int[9];
    [SerializeField] private GetServerData _getServerData;

    public IEnumerator ServerCor()
    {
        StartCoroutine(_getServerData.PostServerData());

        yield return new WaitUntil(() => _getServerData.HasGetData == true);

        SlotNumber = _getServerData.ServerData.Arr;
        WinMoney = _getServerData.ServerData.WinMoney;
    }
}
