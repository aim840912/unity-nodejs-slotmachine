using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

// ! 按按鈕之後的行為

public class ServerProcess : MonoBehaviour
{

    [SerializeField] protected string connectUrl = "";
    [SerializeField] protected TMP_Text _inputField;



    public void ClickToConnectServer()
    {
        StartCoroutine(PostServerData());
    }

    public IEnumerator PostServerData()
    {
        ServerData _serverData = new ServerData();

        WWWForm form = new WWWForm();

        form.AddField("InputValue", _inputField.text);
        form.AddField("userId", PlayerManager.instance.PlayerData.userId);

        UnityWebRequest www = UnityWebRequest.Post(connectUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Form upload complete!");

            Debug.Log(www.downloadHandler.text);

            _serverData = JsonUtility.FromJson<ServerData>(www.downloadHandler.text);
            Debug.Log(_serverData);
            Debug.Log(_serverData.arr);
            Debug.Log(_serverData.money);
            Debug.Log(_serverData.isGetData);
        }
        else
        {
            Debug.Log(www.error);
        }
    }

    private bool IsGetData()
    {
        return PlayerManager.instance.PlayerData.userId == "" ? false : true;
    }


}
