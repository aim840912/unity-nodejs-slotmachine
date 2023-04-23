using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class ServerSignUp : ServerAccount
{
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
            Debug.Log("Form upload complete!");
            _message.text = "sign up Success";
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            _message.text = www.downloadHandler.text;
        }
    }
}
