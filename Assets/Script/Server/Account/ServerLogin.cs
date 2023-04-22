using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;
public struct ErrorMessage
{
    public string message;
}
public class ServerLogin : ServerAccount
{
    [SerializeField] private int _sceneIndexToMainScene = 1;
    PlayerData _playerData;

    protected override IEnumerator PostServerData()
    {
        WWWForm form = new WWWForm();

        form.AddField("email", _email.text);
        form.AddField("password", _password.text);

        UnityWebRequest www = UnityWebRequest.Post(connectUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Form upload complete!");
            _message.text = "SUCCESS";
            Debug.Log(www.downloadHandler.text);

            _playerData = JsonUtility.FromJson<PlayerData>(www.downloadHandler.text);
            Debug.Log(_playerData);
            PlayerManager.instance.PlayerData.userId = _playerData.userId;
            PlayerManager.instance.PlayerData.name = _playerData.name;
            PlayerManager.instance.PlayerData.money = _playerData.money;

            yield return new WaitUntil(() => IsGetData());

            SceneManager.LoadScene(_sceneIndexToMainScene);
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.downloadHandler.text);
            // ErrorMessage returnValue = JsonUtility.FromJson<ErrorMessage>(www.downloadHandler.text);
            // Debug.Log(returnValue);
            _message.text = www.downloadHandler.text;
        }
    }

    private bool IsGetData()
    {
        return PlayerManager.instance.PlayerData.userId == "" ? false : true;
    }
}
