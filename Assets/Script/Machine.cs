using UnityEngine;

public class Machine : MonoBehaviour
{
    private IGameMode _gameMode;
    [SerializeField] private SpinControl _spinControl;

    private void Start()
    {
        if (GameManager.Instance.GameMode == GameMode.ONLINE)
        {
            _gameMode = new Online();
        }
        else
        {
            _gameMode = new SingleGame();
        }
    }

    public void Spin()
    {
        if (!GameManager.Instance.CheckHasInternet())
        {
            return;
        }

        _spinControl.Spin(_gameMode);
    }
}