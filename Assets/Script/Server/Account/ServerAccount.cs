using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public abstract class ServerAccount : MonoBehaviour
{
    protected TMP_InputField account;
    protected TMP_InputField password;
    protected TMP_Text message;

    [SerializeField] protected string connectUrl = "";

    protected abstract void ServerAction();

    protected WWWForm wwwForm;

    protected abstract IEnumerator AccountAct();

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("account", account.text);
        form.AddField("password", password.text);

        UnityWebRequest www = UnityWebRequest.Post(connectUrl, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            message.text = "登入失敗";
        }
        else
        {
            Debug.Log("Form upload complete!");
            message.text = "登入成功";
            Debug.Log(www.downloadHandler.text);
            // ProcessServerResponse(www.downloadHandler.text);

            // MyData = JsonUtility.FromJson<Data>(www.downloadHandler.text);
            // Debug.Log(MyData);
            // MoneyManger.Instance.Name = MyData.userId;
            // MoneyManger.Instance.Money = MyData.money;
            // MoneyManger.Instance.Account = MyData.account;
            SceneManager.LoadScene("SlotMachine");
        }
    }


}
