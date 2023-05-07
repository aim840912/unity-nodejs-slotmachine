using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SceneEnum
{
    CHOOSE_GAME_MODE,
    SIGNUP,
    LOGIN,
    MACHINE,
}

public class SceneChangeHandler : MonoBehaviour
{
    public SceneEnum SceneEnum;

    public void MoveToScene()
    {
        SceneManager.LoadScene((int)SceneEnum);
    }
}