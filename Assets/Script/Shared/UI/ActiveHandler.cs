using UnityEngine;
using UnityEngine.UI;

public class ActiveHandler : MonoBehaviour
{
    public void ChangeActive(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void CloseAll(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(false);
        }
    }

}
