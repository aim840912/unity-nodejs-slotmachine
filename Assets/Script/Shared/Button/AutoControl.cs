using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class AutoControl : MonoBehaviour
{
    [SerializeField] TMP_Text _autoValue;
    public int CurrentAuto { get; private set; } = 0;

    public int AutoTime;

    public void AddAuto()
    {
        if (CurrentAuto <= AutoTime)
            CurrentAuto++;

        CheckAutoNumber();
    }

    public void MinusAuto()
    {
        if (CurrentAuto >= 0)
            CurrentAuto--;

        CheckAutoNumber();
    }

    public void MaxAuto()
    {
        CurrentAuto = 10;

        CheckAutoNumber();
    }

    void CheckAutoNumber()
    {
        if (CurrentAuto > AutoTime)
            CurrentAuto = 0;

        _autoValue.text = $"{CurrentAuto}";
    }

    public void SetZero()
    {
        CurrentAuto = 0;
        _autoValue.text = $"{CurrentAuto}";
    }

    public int GetAutoSpinValue()
    {
        return int.Parse(_autoValue.text);
    }
}
