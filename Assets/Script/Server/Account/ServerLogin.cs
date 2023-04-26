using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ServerLogin : BaseServerAction
{
    private PlayerData _playerData;
    [SerializeField] private int _machineSceneIndex;

    protected override IEnumerator PostServerData()
    {
        WWWForm form = new WWWForm();

        form.AddField("email", _email.text);
        form.AddField("password", _password.text);

        UnityWebRequest www = UnityWebRequest.Post(connectUrl, form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            _playerData = JsonUtility.FromJson<PlayerData>(www.downloadHandler.text);

            PlayerManager.instance.PlayerData.UserId = _playerData.UserId;
            PlayerManager.instance.PlayerData.Name = _playerData.Name;
            PlayerManager.instance.PlayerData.Money = _playerData.Money;

            yield return new WaitUntil(() => HasGetPlayerData());

            SceneManager.LoadScene(_machineSceneIndex);
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            _message.text = www.downloadHandler.text;
        }
    }

    private bool HasGetPlayerData()
    {
        return PlayerManager.instance.PlayerData.UserId == "" ? false : true;
    }
}
