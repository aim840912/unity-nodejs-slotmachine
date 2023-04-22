using System.Collections;
using UnityEngine;
using TMPro;

public abstract class ServerAccount : MonoBehaviour
{
    [SerializeField] protected TMP_InputField _name;
    [SerializeField] protected TMP_InputField _email;
    [SerializeField] protected TMP_InputField _password;
    [SerializeField] protected TMP_Text _message;
    [SerializeField] protected string connectUrl = "";

    public virtual void ClickToConnectServer()
    {
        StartCoroutine(PostServerData());
    }

    protected abstract IEnumerator PostServerData();
}
