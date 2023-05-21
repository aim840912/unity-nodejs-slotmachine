using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : AccountBase
{
    private PlayerData _playerData;
    [SerializeField] private Toggle _rememberToggle;
    [SerializeField] private SceneEnum _nextScene;

    private void Start()
    {
        _email.text = PlayerPrefs.GetString("email");
    }

    protected override IEnumerator connectToServer()
    {
        RememberLoginInform();
        WWWForm form = new WWWForm();

        form.AddField("email", _email.text);
        form.AddField("password", _password.text);

        UnityWebRequest www = UnityWebRequest.Post(GameManager.Instance.UrlData.LoginUrl, form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            _playerData = JsonUtility.FromJson<PlayerData>(www.downloadHandler.text);

            PlayerManager.instance.UpdatePlayerManager(_playerData);

            yield return new WaitUntil(() => HasGetPlayerData());

            LoadToNextScene(_nextScene);
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            OpenPanel(www.downloadHandler.text);
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
            PlayerPrefs.SetString("email", _email.text);
        else
            PlayerPrefs.SetString("email", "");
    }

    private void LoadToNextScene(SceneEnum sceneEnum)
    {
        SceneManager.LoadScene((int)sceneEnum);
    }
}
