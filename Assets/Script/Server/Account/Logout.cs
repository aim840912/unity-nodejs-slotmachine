using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    public void LogOut()
    {
        PlayerManager.instance.ResetPlayerManager();
        SceneManager.LoadScene((int)SceneEnum.CHOOSE_GAME_MODE);
    }
}