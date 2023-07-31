using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [HeaderAttribute("Input Field")]
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _password;

    [HeaderAttribute("Message")]
    [SerializeField] private GameObject _messagePanel;
    [SerializeField] private TMP_Text _message;

    private PlayerData _playerData;
    [SerializeField] private Toggle _rememberToggle;
    [SerializeField] private SceneEnum _nextScene;

    private void Start()
    {
        _email.text = PlayerPrefs.GetString("email");
    }

    public void ClickToConnectServer()
    {
        StartCoroutine(connectToServer());
    }

    private IEnumerator connectToServer()
    {
        RememberAccountNumber();
        WWWForm form = new WWWForm();

        form.AddField("email", _email.text);
        form.AddField("password", _password.text);

        UnityWebRequest www = UnityWebRequest.Post(GameManager.Instance.UrlData.LoginUrl, form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            _playerData = JsonUtility.FromJson<PlayerData>(www.downloadHandler.text);

            PlayerManager.instance.SetPlayerData(_playerData);

            yield return new WaitUntil(() => HasGetPlayerData());

            LoadToNextScene(_nextScene);
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            OpenMessagePanel(www.downloadHandler.text);
        }

        www.Dispose();
    }

    private bool HasGetPlayerData() => PlayerManager.instance.GetPlayerId() == "" ? false : true;


    private void RememberAccountNumber()
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

    private void OpenMessagePanel(string message)
    {
        _messagePanel.SetActive(true);
        _message.text = message;
    }
}
