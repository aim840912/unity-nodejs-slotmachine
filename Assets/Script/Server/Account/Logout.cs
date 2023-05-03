using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    public void LogOut(string sceneName)
    {
        PlayerManager.instance.ResetPlayerManager();
        SceneManager.LoadScene(sceneName);
    }
}