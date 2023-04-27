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
    public int PlayerMoney { get; set; }
    [SerializeField] private string _connectUrl = "";
    [SerializeField] private TMP_Text _betInputValue;
    private ServerReturnData _serverReturnData;
    private bool _hasGetData;

    public IEnumerator GetServerData()
    {
        StartCoroutine(GetReturnData());

        yield return new WaitUntil(() => _hasGetData == true);

        SlotNumber = _serverReturnData.BoardNum;
        WinMoney = _serverReturnData.WinMoney;
        PlayerMoney = _serverReturnData.Money;
    }

    private IEnumerator GetReturnData()
    {
        _hasGetData = false;

        WWWForm form = new WWWForm();

        form.AddField("InputValue", _betInputValue.text);
        form.AddField("userId", PlayerManager.instance.PlayerData.UserId);

        UnityWebRequest www = UnityWebRequest.Post(_connectUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            _hasGetData = true;

            _serverReturnData = JsonUtility.FromJson<ServerReturnData>(www.downloadHandler.text);

            PlayerManager.instance.PlayerData.Money = _serverReturnData.Money;
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.result);
        }
    }
}
