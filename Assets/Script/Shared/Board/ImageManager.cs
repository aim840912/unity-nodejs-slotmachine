using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private ImageControl[] _imageControls;

    public bool CanNextStep;

    public void Spin()
    {
        CanNextStep = false;

        for (int i = 0; i < _imageControls.Length; i++)
        {
            _imageControls[i].StartLoop();
        }
    }

    public void Stop(int[] boardNum)
    {
        for (int i = 0; i < _imageControls.Length; i++)
        {
            StartCoroutine(_imageControls[i].StopRoutine(boardNum[i]));
        }

        StartCoroutine(WaitCanNextStep());
    }

    private IEnumerator WaitCanNextStep()
    {
        yield return new WaitUntil(() => CheckCanNextStep());

        CanNextStep = true;
    }

    public bool CheckCanNextStep()
    {
        int boolCount = 0;
        for (int i = 0; i < _imageControls.Length; i++)
        {
            if (_imageControls[i].IsOver == true)
            {
                boolCount++;
            }
        }

        return boolCount == _imageControls.Length ? true : false;
    }
}