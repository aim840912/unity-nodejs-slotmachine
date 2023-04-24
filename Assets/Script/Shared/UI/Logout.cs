using UnityEngine;
using UnityEngine.UI;

public class Logout : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void ChangePanelActive()
    {
        _panel.SetActive(!_panel.activeSelf);
    }


}

