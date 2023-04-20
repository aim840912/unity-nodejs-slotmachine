using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class ServerSignUp : MonoBehaviour
{
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private TMP_Text _message;
    [SerializeField] private string connectUrl = "http://localhost:3000/user/signup";

    public void CheckToSignup()
    {
        StartCoroutine(SignUp());
    }

    IEnumerator SignUp()
    {
        Debug.Log("signup");
        WWWForm form = new WWWForm();
        form.AddField("name", _name.text);
        form.AddField("email", _email.text);
        form.AddField("password", _password.text);

        UnityWebRequest www = UnityWebRequest.Post(connectUrl, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            _message.text = www.error;
            // message.text = www.error;
        }
        else
        {
            Debug.Log("Form upload complete!");
            _message.text = "Success";
        }
    }
}
