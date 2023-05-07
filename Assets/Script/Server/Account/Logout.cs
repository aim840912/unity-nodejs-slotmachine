using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    public void LogOut()
    {
        PlayerManager.instance.ResetPlayerManager();
    }
}