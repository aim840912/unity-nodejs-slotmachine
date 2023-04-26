using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class ServerSignUp : BaseServerAction
{
    [SerializeField] private GameObject _panel;

    protected override IEnumerator PostServerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", _name.text);
        form.AddField("email", _email.text);
        form.AddField("password", _password.text);

        UnityWebRequest www = UnityWebRequest.Post(connectUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            _message.text = "sign up Success";

            _panel.SetActive(true);

        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            _message.text = www.downloadHandler.text;
        }
    }

    public void ClickToClosePanel()
    {
        _panel.SetActive(false);
    }
}
