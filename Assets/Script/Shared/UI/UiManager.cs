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
        _playerMoneyText.text = $"{PlayerManager.instance.PlayerData.Money}";
    }


    public void UpdatedPlayerUI(IGameMode server)
    {
        int winMoney = server.BackendData.WinMoney;
        int playerMoney = server.BackendData.Money;

        _winMoneyText.text = $"Win: {winMoney}";
        _playerMoneyText.text = $"{playerMoney}";

        CheckValue(_betControl);
        CheckValue(_autoControl);
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

    private void CheckValue(ValueControl valueControl)
    {
        valueControl.ValueCheck();
    }

    public void OnlyOpenOnePanel(GameObject gameObject)
    {
        CloseAllPanel();
        gameObject.SetActive(true);
    }

}
