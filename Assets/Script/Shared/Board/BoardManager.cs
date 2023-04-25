using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private ImageControl[] _imageControls;

    public bool IsOver = false;

    public void Spin()
    {
        IsOver = false;
        for (int i = 0; i < _imageControls.Length; i++)
        {
            _imageControls[i].StartLoop();
        }
    }

    public void Stop(int[] boardNum)
    {
        for (int i = 0; i < _imageControls.Length; i++)
        {
            StartCoroutine(_imageControls[i].SetTimeToStopSpin(boardNum[i]));
        }

        StartCoroutine(WaitTime(2));
    }

    private IEnumerator WaitTime(int time)
    {
        yield return new WaitForSeconds(time);
        IsOver = true;
    }

}