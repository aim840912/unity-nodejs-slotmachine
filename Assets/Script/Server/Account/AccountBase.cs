using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public abstract class AccountBase : MonoBehaviour
{
    [HeaderAttribute("Input Setting")]
    [SerializeField] protected TMP_InputField _name;
    [SerializeField] protected TMP_InputField _email;
    [SerializeField] protected TMP_InputField _password;

    [HeaderAttribute("Message")]
    [SerializeField] protected GameObject _messagePanel;
    [SerializeField] protected TMP_Text _message;

    public virtual void ClickToConnectServer()
    {
        StartCoroutine(connectToServer());
    }

    protected abstract IEnumerator connectToServer();


    protected virtual void OpenPanel(string message)
    {
        _messagePanel.SetActive(true);
        _message.text = message;
    }

}
