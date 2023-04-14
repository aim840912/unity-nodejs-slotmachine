using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShowImage : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    public void IsShowing()
    {
        _gameObject.SetActive(!_gameObject.activeSelf);
    }
}
