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

[RequireComponent(typeof(Button))]
public class SceneChangeHandler : MonoBehaviour
{
    public SceneEnum SceneEnum;

    public void ClickToScene()
    {
        SceneManager.LoadScene((int)SceneEnum);
    }
}