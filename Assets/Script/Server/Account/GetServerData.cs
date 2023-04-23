using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class GetServerData : MonoBehaviour
{
    [SerializeField] private string connectUrl = "";
    [SerializeField] private TMP_Text _betInputValue;
    public ServerData ServerData { get; private set; }
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

            Debug.Log(www.downloadHandler.text);

            ServerData = JsonUtility.FromJson<ServerData>(www.downloadHandler.text);
            Debug.Log(ServerData.Arr);
            Debug.Log(ServerData.Money);
            Debug.Log(ServerData.HasGetData);
            Debug.Log(ServerData.WinMoney);
        }
        else
        {
            Debug.Log(www.error);
        }
    }



}
