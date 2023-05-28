using UnityEngine;
using System.Collections;

public class SpinRenew : MonoBehaviour
{
    [SerializeField] private BetButtonControl _betControl;
    [SerializeField] private AutoButtonControl _autoControl;

    [SerializeField] private BoardManagerRenew _boardManagerRenew;
    private IGameMode _gameMode;

    private Coroutine _coroutine = null;
    private float _loopStopTime = 3f;

    public void Spin(IGameMode gameMode)
    {
        this._gameMode = gameMode;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(Auto());
    }

    private IEnumerator Auto()
    {
        _loopStopTime = GetAutoValue() < 1 ? 5f : 2f;

        if (_boardManagerRenew.IsOver == true)
        {
            Rotate();
            yield return new WaitForSeconds(_loopStopTime);
        }

        if (_boardManagerRenew.IsOver == false)
        {
            StopRotate();
        }

        yield return new WaitUntil(() => _boardManagerRenew.IsOver == true);

        _autoControl.LoopOverOneTime();

        if (GetAutoValue() < 1)
            yield break;

        _coroutine = StartCoroutine(Auto());
    }

    private void Rotate()
    {
        if (!GameManager.Instance.CheckHasInternet())
        {
            return;
        }
        StartCoroutine(_gameMode.GetServerData(GetBetValue()));
        _boardManagerRenew.Spin();
    }

    private void StopRotate()
    {
        StartCoroutine(_boardManagerRenew.Stop(_gameMode.BackendData));
    }

    private int GetAutoValue() => _autoControl.CurrentValue;

    private int GetBetValue() => _betControl.CurrentValue;


}