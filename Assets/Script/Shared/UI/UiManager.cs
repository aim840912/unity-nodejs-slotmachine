using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _winMoneyText;
    [SerializeField] private TMP_Text _playerMoneyText;
    public BetButtonControl _betControl;
    public AutoButtonControl _autoControl;
    [SerializeField] private GameObject[] _panel;

    private void Start()
    {
        _playerMoneyText.text = $"{PlayerManager.instance.PlayerMoney}";
    }


    public void UpdatedPlayerUI(IGameMode server)
    {
        int winMoney = server.BackendData.WinMoney;
        int playerMoney = server.BackendData.Money;

        _winMoneyText.text = $"Win: {winMoney}";
        _playerMoneyText.text = $"{playerMoney}";
    }

    public void TurnWinMoneyToZero()
    {
        _winMoneyText.text = $"Win: {0}";
    }

    public void CloseAllPanel()
    {
        for (int i = 0; i < _panel.Length; i++)
        {
            _panel[i].SetActive(false);
        }
    }

    public bool IsBetAvailable()
    {
        if (_betControl.CurrentValue * _autoControl.CurrentValue > PlayerManager.instance.PlayerMoney)
        {
            _betControl.CurrentValue = 0;
            _autoControl.CurrentValue = 0;

            return false;
        }
        return true;
    }

    public void OnlyOpenOnePanel(GameObject gameObject)
    {
        CloseAllPanel();
        gameObject.SetActive(true);
    }

}
