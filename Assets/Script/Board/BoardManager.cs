using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private ImageControl[] _imageControls;

    public void Spin()
    {
        for (int i = 0; i < _imageControls.Length; i++)
        {
            _imageControls[i].StartLoop();
        }
    }

    public void Stop(int[] boardNum)
    {
        // foreach (var item in boardNum)
        // {
        //     Debug.Log(item);
        // }
        for (int i = 0; i < _imageControls.Length; i++)
        {
            StartCoroutine(_imageControls[i].SetTimeToStopSpin(boardNum[i]));
        }
    }
}