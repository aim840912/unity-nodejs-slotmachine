using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerLogout : MonoBehaviour
{
    public void Logout(int _sceneIndexToMainScene)
    {
        PlayerManager.instance.PlayerData.UserId = "";
        PlayerManager.instance.PlayerData.Name = "";
        PlayerManager.instance.PlayerData.Money = 0;

        SceneManager.LoadScene(_sceneIndexToMainScene);
    }
}