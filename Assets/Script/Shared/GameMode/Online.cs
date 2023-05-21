using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Online : IGameMode
{
    public BackendData BackendData { get; set; } = new BackendData();

    public IEnumerator GetServerData(int betInputValue)
    {
        WWWForm form = new WWWForm();

        form.AddField("InputValue", betInputValue);
        form.AddField("userId", PlayerManager.instance.PlayerData.UserId);

        UnityWebRequest www = UnityWebRequest.Post(GameManager.Instance.UrlData.MachineUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            BackendData = JsonUtility.FromJson<BackendData>(www.downloadHandler.text);
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            BackendData = null;
            Debug.Log("spin GET DATA ERROR");
        }

        www.Dispose();
    }
}
