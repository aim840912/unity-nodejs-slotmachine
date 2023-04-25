using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerLogout : MonoBehaviour
{
    public void Logout(string sceneName)
    {
        PlayerManager.instance.PlayerData.UserId = "";
        PlayerManager.instance.PlayerData.Name = "";
        PlayerManager.instance.PlayerData.Money = 0;

        SceneManager.LoadScene(sceneName);
    }
}