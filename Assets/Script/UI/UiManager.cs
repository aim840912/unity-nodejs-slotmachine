using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _winMoneyText;
    // [SerializeField] private TMP_Text _playerMoneyText;
    [SerializeField] private BetControl _betControl;

    public void UpdatedPlayerUI(Server server)
    {
        int winMoney = server.WinMoney;
        int playerMoney = PlayerManager.instance.PlayerMoney;

        _winMoneyText.text = $"Win: {winMoney}";
        // _playerMoneyText.text = $"{playerMoney}";
    }

    public int GetBet()
    {
        return _betControl.CurrentBet;
    }

}
