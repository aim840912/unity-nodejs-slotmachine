using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class ServerReturnData
{
    public int[] BoardNum;
    public int WinMoney;
    public int Money = 10000;
}

public class Server : MonoBehaviour, IGameMode
{

    public ServerReturnData ServerReturnData { get; set; }
    public bool GetData { get; set; }

    [SerializeField] private string _connectUrl = "http://localhost:3000/machine/spinAction";

    public IEnumerator GetServerData(int betInputValue)
    {
        StartCoroutine(GetReturnData(betInputValue));

        yield return new WaitUntil(() => GetData == true);

        PlayerManager.instance.PlayerData.Money = ServerReturnData.Money;
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
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            GetData = false;
            Debug.Log(www.result);
        }
    }
}
