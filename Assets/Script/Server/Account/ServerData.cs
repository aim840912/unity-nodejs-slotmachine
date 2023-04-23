using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public struct ServerReturnData
{
    public int[] Arr;
    public int WinMoney;
    public int Money;
    public bool HasGetData;
}

public class ServerData : MonoBehaviour
{
    [SerializeField] private string connectUrl = "";
    [SerializeField] private TMP_Text _betInputValue;
    public ServerReturnData ServerReturnData { get; private set; }
    public bool HasGetData { get; private set; }

    public void ClickToConnectServer()
    {
        StartCoroutine(PostServerData());
    }

    public IEnumerator PostServerData()
    {
        HasGetData = false;

        WWWForm form = new WWWForm();
        form.AddField("InputValue", _betInputValue.text);
        form.AddField("userId", PlayerManager.instance.PlayerData.UserId);

        UnityWebRequest www = UnityWebRequest.Post(connectUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            HasGetData = true;

            ServerReturnData = JsonUtility.FromJson<ServerReturnData>(www.downloadHandler.text);

            PlayerManager.instance.PlayerData.Money = ServerReturnData.Money;
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.result);
        }
    }
}
