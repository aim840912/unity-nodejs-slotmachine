using UnityEngine;

public class Machine : MonoBehaviour
{
    private SingleGame _singleGame = new SingleGame();
    private Online _online = new Online();

    [SerializeField] private SpinControl _spinControl;

    private IGameMode GetGameMode() => GameManager.Instance.GameMode == GameMode.ONLINE ? _online : _singleGame;

    public void Spin()
    {
        if (!GameManager.Instance.CheckHasInternet())
        {
            return;
        }

        _spinControl.Spin(GetGameMode());
    }
}