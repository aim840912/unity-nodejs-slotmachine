using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SignUp : AccountBase
{
    [SerializeField] private GameObject _panel;

    protected override IEnumerator connectToServer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", _name.text);
        form.AddField("email", _email.text);
        form.AddField("password", _password.text);

        UnityWebRequest www = UnityWebRequest.Post(_urlData.SignupUrl, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            OpenPanel("Sign Up Success");
        }
        else if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            OpenPanel(www.downloadHandler.text);
        }
    }
}
