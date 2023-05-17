using UnityEngine;
using UnityEngine.UI;
using System;

//! 嘗試中 尚未實作
public class BetManager : MonoBehaviour
{
    [SerializeField] private BetButtonControl _betControl;
    [SerializeField] private AutoButtonControl _autoControl;

    public bool IsBetAvailable()
    {
        if (PlayerManager.instance.PlayerMoney > _betControl.CurrentValue * _autoControl.CurrentValue)
        {
            return true;
        }

        _betControl.CurrentValue = 0;
        _autoControl.CurrentValue = 0;

        return false;
    }

    public void LoopOneTime()
    {
        if (_autoControl.CurrentValue > 0)
        {
            _autoControl.CurrentValue--;
            _autoControl.ValueCheck();
        }
    }

    public int GetBetValue()
    {

        return _betControl.CurrentValue;
    }

    public int GetAutoValue()
    {
        return _autoControl.CurrentValue;
    }

}