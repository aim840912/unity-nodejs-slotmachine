using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class ServerLogin : MonoBehaviour
{
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_Text message;
    [SerializeField] private string connectUrl = "http://localhost:3000/user/login";

    [SerializeField] private int _sceneIndexToMainScene = 1;

    PlayerData _playerData;


    public void CheckToLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", _email.text);
        form.AddField("password", password.text);

        UnityWebRequest www = UnityWebRequest.Post(connectUrl, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            message.text = "FAIL";
        }
        else
        {
            Debug.Log("Form upload complete!");
            message.text = "SUCCESS";
            Debug.Log(www.downloadHandler.text);

            _playerData = JsonUtility.FromJson<PlayerData>(www.downloadHandler.text);
            Debug.Log(_playerData);
            PlayerManager.instance.PlayerData.userId = _playerData.userId;
            PlayerManager.instance.PlayerData.name = _playerData.name;
            PlayerManager.instance.PlayerData.money = _playerData.money;

            yield return new WaitUntil(() => IsGetData());

            SceneManager.LoadScene(_sceneIndexToMainScene);
        }
    }

    private bool IsGetData()
    {
        if (PlayerManager.instance.PlayerData.userId != "")
        {
            Debug.Log(PlayerManager.instance.PlayerData.userId);
            return true;
        }
        else
        {
            Debug.Log(PlayerManager.instance.PlayerData.userId);
            return false;
        }

    }
}
