using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _winMoneyText;
    [SerializeField] private TMP_Text _playerMoneyText;
    [SerializeField] private BetControl _betControl;

    private void Start()
    {
        int playerMoney = PlayerManager.instance.PlayerData.Money;
        _playerMoneyText.text = $"{playerMoney}";
    }

    public void UpdatedPlayerUI(Server server)
    {
        int winMoney = server.WinMoney;
        int playerMoney = PlayerManager.instance.PlayerData.Money;

        _winMoneyText.text = $"Win: {winMoney}";
        _playerMoneyText.text = $"{playerMoney}";
    }

    public void TurnValueToZero()
    {
        _winMoneyText.text = $"Win: {0}";
    }

}
