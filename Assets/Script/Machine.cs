using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private BoardManager _boardManager;

    [HeaderAttribute("Game mode")]
    [SerializeField] private SingleGame _singleGame;
    private Online _online = new Online();

    private NormalSpin _normalSpin;
    private AutoSpin _autoSpin;


    [HeaderAttribute("Bet and Auto Control")]
    [SerializeField] private BetButtonControl _betControl;
    [SerializeField] private AutoButtonControl _autoControl;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _normalSpin = new NormalSpin(_betControl, _autoControl, _boardManager, GetGameMode(), this);
        _autoSpin = new AutoSpin(_betControl, _autoControl, _boardManager, GetGameMode(), this);
    }

    private IGameMode GetGameMode() => GameManager.Instance.GameMode == GameMode.ONLINE ? _online : _singleGame;

    private SpinBase SpinType() => _autoControl.CurrentValue == 0 ? _normalSpin : _autoSpin;


    public void Spin()
    {
        if (!_betControl.ValueCheck())
            return;

        SpinType().SpinHandler();
    }

}