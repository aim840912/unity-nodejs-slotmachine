using UnityEngine;

public class SignUp : MonoBehaviour
{
    private string singUpUrl = "";

    public void OpenUrl()
    {
        Application.OpenURL(singUpUrl);
    }
}
