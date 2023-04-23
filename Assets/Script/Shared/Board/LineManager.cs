using System;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private LineControl[] _lineControls;

    public void Spin()
    {
        for (int i = 0; i < _lineControls.Length; i++)
        {
            _lineControls[i].LineDisabled();
        }
    }

    public void Stop(int[] boardNum)
    {

        for (int i = 0; i < _lineControls.Length; i++)
        {
            _lineControls[i].LineEnabled(boardNum);
        }
    }
}