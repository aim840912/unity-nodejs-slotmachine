using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public abstract class AccountBase : MonoBehaviour
{
    [SerializeField] protected TMP_InputField _name;
    [SerializeField] protected TMP_InputField _email;
    [SerializeField] protected TMP_InputField _password;
    [SerializeField] protected TMP_Text _message;
    [SerializeField] protected string _connectUrl = "";

    public virtual void ClickToConnectServer()
    {
        StartCoroutine(PostServerData());
    }

    protected abstract IEnumerator PostServerData();

    public virtual void ClickToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
