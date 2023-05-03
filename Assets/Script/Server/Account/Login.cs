using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : AccountBase
{
    private PlayerData _playerData;
    private string _loadSceneName = "Machine Scene";
    [SerializeField] private Toggle _rememberToggle;

    private void Start()
    {
        _email.text = PlayerPrefs.GetString("email");
    }

    protected override IEnumerator PostServerData()
    {
        RememberLoginInform();
        WWWForm form = new WWWForm();

        form.AddField("email", _email.text);
        form.AddField("password", _password.text);

        UnityWebRequest www = UnityWebRequest.Post(_connectUrl, form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            _playerData = JsonUtility.FromJson<PlayerData>(www.downloadHandler.text);

            PlayerManager.instance.UpdatePlayerManager(_playerData);

            yield return new WaitUntil(() => HasGetPlayerData());

            SceneManager.LoadScene(_loadSceneName);
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            _message.text = www.downloadHandler.text;
        }

        www.Dispose();
    }

    private bool HasGetPlayerData()
    {
        return PlayerManager.instance.PlayerData.UserId == "" ? false : true;
    }

    private void RememberLoginInform()
    {
        if (_rememberToggle.isOn)
        {
            PlayerPrefs.SetString("email", _email.text);
        }
        else
        {
            PlayerPrefs.SetString("email", "");
        }
    }
}
