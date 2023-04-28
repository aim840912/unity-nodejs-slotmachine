using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public struct ServerReturnData
{
    public int[] BoardNum;
    public int WinMoney;
    public int Money;
}

public class Server : MonoBehaviour, IGameMode
{
    public int WinMoney { get; set; }
    public int[] SlotNumber { get; set; } = new int[9];

    [SerializeField] private string _connectUrl = "http://localhost:3000/machine/spinAction";

    public ServerReturnData ServerReturnData { get; set; }

    public bool GetData { get; set; }

    public IEnumerator GetServerData(int betInputValue)
    {
        StartCoroutine(GetReturnData(betInputValue));

        yield return new WaitUntil(() => GetData == true);

        SlotNumber = ServerReturnData.BoardNum;
        WinMoney = ServerReturnData.WinMoney;
    }

    private IEnumerator GetReturnData(int betInputValue)
    {
        GetData = false;

        WWWForm form = new WWWForm();

        form.AddField("InputValue", betInputValue);
        form.AddField("userId", PlayerManager.instance.PlayerData.UserId);

        UnityWebRequest www = UnityWebRequest.Post(_connectUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            GetData = true;

            ServerReturnData = JsonUtility.FromJson<ServerReturnData>(www.downloadHandler.text);

            // PlayerManager.instance.PlayerData.Money = ServerReturnData.Money;
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.result);
        }
    }
}
