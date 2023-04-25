using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _winMoneyText;
    [SerializeField] private TMP_Text _playerMoneyText;
    [SerializeField] private BetControl _betControl;
    [SerializeField] private GameObject[] _panel;


    // private void Start()
    // {
    //     int playerMoney = PlayerManager.instance.PlayerData.Money;
    //     _playerMoneyText.text = $"{playerMoney}";
    // }

    public void UpdatedPlayerUI(IGameMode server)
    {
        int winMoney = server.WinMoney;
        int playerMoney = PlayerManager.instance.PlayerData.Money;

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

}
