using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShowImage : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void IsShowing()
    {
        _image.enabled = !_image.enabled;
    }
}
